﻿using System;
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
        private static readonly decimal defaultInterestRate = 0.01m;
        private readonly IAccountRepo _repo;
        private readonly UserManager<AppUser> userManager;

        public AccountsController(IAccountRepo repo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            this.userManager = userManager;
        }

        // GET: BusinessAccounts

        public async Task<IActionResult> Index()
        {
            return View((await _repo.GetBusiness()).Where<Account>(b => b.AppUserId == userManager.GetUserId(User)));
        }

        // GET: BusinessAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _repo.GetBusiness(id);
            if (businessAccount == null)
            {
                return NotFound();
            }
            AccountVM bavm = new AccountVM
            {
                Account = businessAccount,
                Transactions = (await _repo.GetBusinessTransactions())
                    .Where(acct => acct.AccountID == id)
                    .Reverse()
                    .Take(10)
                    .ToList()
            };
            return View(bavm);
        }

        public async Task<IActionResult> Transactions(int id, [Bind("Start, End")] TransactionsVM tlvm)
        {
            if (tlvm.Start <= new DateTime(2019,10,31))
            {
                tlvm.Start = new DateTime(2019, 10, 31);
            }
            if (tlvm.End < tlvm.Start)
            {
                tlvm.End = tlvm.Start;
            }
            var trans = (await _repo.GetBusinessTransactions())
                    .Where(trans => (trans.AccountID == id))
                    .Where(trans => trans.TransTime >= tlvm.Start)
                    .Where(trans => trans.TransTime <= tlvm.End.AddDays(1).AddSeconds(-1))
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
            return View(tlvm);
        }

        // GET: BusinessAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: BusinessAccounts/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NickName, AccountType")] Account account)
        {
            account.AppUserId = userManager.GetUserId(User);
            account.DateCreated = DateTime.Now;
            account.InterestRate = defaultInterestRate;
            if (ModelState.IsValid)
            {
                switch (account.AccountType)
                {
                    case "Business":
                        {
                            BusinessAccount bAcct = new BusinessAccount { 
                                AppUserId = account.AppUserId,
                                DateCreated = account.DateCreated,
                                InterestRate = account.InterestRate,
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
                                InterestRate = account.InterestRate,
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

        // GET: BusinessAccounts/Close/5
        public async Task<IActionResult> Close(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _repo.GetBusiness(id);
            if (businessAccount == null)
            {
                return NotFound();
            }

            return View(businessAccount);
        }

        // POST: BusinessAccounts/Close/5
        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseConfirmed(int id)
        {
            await _repo.Close(await _repo.GetBusiness(id));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bAccount = await _repo.GetBusiness(id);
            DepositVM depositVM = new DepositVM { Amount = 0 };

            if (bAccount == null)
            {
                return NotFound();
            }

            return View(depositVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(int id, [Bind("Amount")] DepositVM depositVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Deposit(await _repo.GetBusiness(id), depositVM.Amount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAccountExists(id))
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
            var account = await _repo.GetBusiness(id);
            WithdrawlVM withdrawlVM = new WithdrawlVM { Amount = 0 };

            if (account == null)
            {
                return NotFound();
            }

            return View(withdrawlVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(int id, [Bind("Amount")] WithdrawlVM withdrawlVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Withdraw(await _repo.GetBusiness(id), withdrawlVM.Amount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAccountExists(id))
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
            var bAccount = await _repo.GetBusiness(id);

            if (bAccount == null)
            {
                return NotFound();
            }
            //return RedirectToAction(nameof(Index));
            var accounts = (await _repo.GetBusiness(userManager.GetUserId(User)))
                .Where(b => !b.IsClosed)
                .Except(new List<Account> { bAccount });
            List<Account> validAccounts = new List<Account>();
            foreach (var item in accounts)
            {
                validAccounts.Add(item);
            }
            return View(new TransferVM { Accounts = validAccounts, AccountIDFrom = (int)id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(int id, [Bind("AccountIDTo, Amount")] TransferVM transferVM)
        {
            var accounts = (await _repo.GetBusiness(userManager.GetUserId(User)))
                .Where(b => !b.IsClosed)
                .Except(new List<Account> { await _repo.GetBusiness(id) });
            List<Account> validAccounts = new List<Account>();
            foreach (var item in accounts)
            {
                validAccounts.Add(item);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Transfer(await _repo.GetBusiness(id), await _repo.GetBusiness(transferVM.AccountIDTo), transferVM.Amount);
                }
                catch //(DbUpdateConcurrencyException)
                {
                    if (!BusinessAccountExists(id))
                    {
                        return NotFound();
                    }
                    else if (!BusinessAccountExists(transferVM.AccountIDTo))
                    {
                        //transferVM.Accounts = validAccounts;
                        //transferVM.AccountIDFrom = (int)id;
                        //return View(transferVM);
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

        private bool BusinessAccountExists(int id)
        {
            return _repo.BusinessAccountExists(id);
        }
    }
}
