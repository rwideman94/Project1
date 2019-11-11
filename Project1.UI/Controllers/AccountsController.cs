using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Models.Accts;
using Project1.Models.Repositories;
using Project1.Models.Transactions;
using Project1.UI.ViewModels;

namespace Project1.UI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepo _repo;
        private readonly UserManager<AppUser> UserManager;

        public AccountsController(IAccountRepo repo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            UserManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var accts = (await _repo.Get()).Where<Account>(a => a.AppUserId == UserManager.GetUserId(User));
            var bAccts = accts.Where(b => b is BusinessAccount);
            var cAccts = accts.Where(c => c is CheckingAccount);
            return View(new IndexVM { Accounts = accts, BusinessAccoutns = bAccts, CheckingAccounts = cAccts });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _repo.Get(id);
            if (account == null)
            {
                return NotFound();
            }
            AccountVM bavm = new AccountVM
            {
                Account = account,
                Transactions = (await _repo.GetTransactions())
                    .Where(acct => acct.AccountID == id)
                    .Reverse()
                    .Take(10)
                    .ToList(),
                AccountUserId = account.AppUserId
            };
            return View(bavm);
        }

        public async Task<IActionResult> Transactions(int id, [Bind("Start, End")] TransactionsVM tlvm)
        {
            if (ModelState.IsValid)
            {
                if (tlvm.Start <= DateTime.UnixEpoch)
                {
                    tlvm.Start = DateTime.Today;
                }
                if (tlvm.End < tlvm.Start)
                {
                    tlvm.End = tlvm.Start.AddDays(1).AddTicks(-1);
                }
                var trans = (await _repo.GetTransactions())
                        .Where(trans => (trans.AccountID == id))
                        .Where(trans => trans.TransTime >= tlvm.Start)
                        .Where(trans => trans.TransTime <= tlvm.End.AddDays(1).AddTicks(-1))
                        .ToList();
                List<Transaction> validTrans = new List<Transaction>();
                foreach (var item in trans)
                {
                    validTrans.Add(item);
                }
                foreach (var item in validTrans)
                {
                    tlvm.Transactions.Add(item);
                }
            }
            return View(tlvm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NickName, AccountType")] Account account)
        {
            account.AppUserId = UserManager.GetUserId(User);
            account.DateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                switch (account.AccountType)
                {
                    case "Business":
                        {
                            BusinessAccount bAcct = new BusinessAccount
                            {
                                AppUserId = account.AppUserId,
                                DateCreated = account.DateCreated,
                                InterestRate = Account.BusinessInterestRate,
                                NickName = account.NickName,
                                AccountType = account.AccountType
                            };
                            await _repo.Add(bAcct);
                            return RedirectToAction(nameof(Index));
                        }
                    case "Checking":
                        {
                            CheckingAccount cAcct = new CheckingAccount
                            {
                                AppUserId = account.AppUserId,
                                DateCreated = account.DateCreated,
                                InterestRate = Account.CheckingInterestRate,
                                NickName = account.NickName,
                                AccountType = account.AccountType
                            };
                            await _repo.Add(cAcct);
                            return RedirectToAction(nameof(Index));
                        }
                    default:
                        {
                            return View(account);
                        }
                }
            }
            return View(account);
        }

        public async Task<IActionResult> Close(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _repo.Get(id);
            if (businessAccount == null)
            {
                return NotFound();
            }

            return View(businessAccount);
        }

        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseConfirmed(int id)
        {
            await _repo.Close(await _repo.Get(id));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _repo.Get(id);
            if (true)
            {

            }
            DepositVM depositVM = new DepositVM { 
                Amount = 0
            };

            if (account == null)
            {
                return NotFound();
            }

            return View(depositVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(int id, [Bind("Amount")] DepositVM depositVM)
        {
            var account = await _repo.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Deposit(account, depositVM.Amount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(depositVM);
        }

        public async Task<IActionResult> Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _repo.Get(id);

            if (account == null)
            {
                return NotFound();
            }
            WithdrawlVM withdrawlVM = new WithdrawlVM { 
                Amount = 0, 
                Balance = account.Balance, 
                AccountType = account.AccountType};

            return View(withdrawlVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(int id, [Bind("Balance", "Amount", "AccountType")] WithdrawlVM withdrawlVM)
        {
            Account account = await _repo.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    if (withdrawlVM.Amount > account.Balance)
                    {
                        await _repo.Overdraft(await UserManager.GetUserAsync(User), account, withdrawlVM.Amount);
                    }
                    else
                    {
                        await _repo.Withdraw(account, withdrawlVM.Amount);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(withdrawlVM);
        }


        public async Task<IActionResult> Transfer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _repo.Get(id);

            if (account == null)
            {
                return NotFound();
            }
            var accounts = (await _repo.Get(UserManager.GetUserId(User)))
                .Where(b => !b.IsClosed)
                .Except(new List<Account> { account });
            List<Account> validAccounts = new List<Account>();
            foreach (var item in accounts)
            {
                validAccounts.Add(item);
            }
            return View(new TransferVM { 
                Accounts = validAccounts, 
                AccountIDFrom = (int)id, 
                AccountFromBalance = account.Balance
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(int id, [Bind("AccountIDFrom, AccountIDTo, Amount, AccountFromBalance")] TransferVM transferVM)
        {
            var accounts = (await _repo.Get(UserManager.GetUserId(User)))
                .Where(b => !b.IsClosed)
                .Except(new List<Account> { await _repo.Get(transferVM.AccountIDFrom) });
            List<Account> validAccounts = new List<Account>();
            foreach (var item in accounts)
            {
                validAccounts.Add(item);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Transfer(await _repo.Get(transferVM.AccountIDFrom), await _repo.Get(transferVM.AccountIDTo), transferVM.Amount);
                }
                catch
                {
                    if (!AccountExists(transferVM.AccountIDFrom))
                    {
                        return NotFound();
                    }
                    else if (!AccountExists(transferVM.AccountIDTo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            transferVM.Accounts = validAccounts;
            transferVM.AccountIDFrom = (int)id;
            return View(transferVM);
        }

        private bool AccountExists(int id)
        {
            return _repo.AccountExists(id);
        }
    }
}
