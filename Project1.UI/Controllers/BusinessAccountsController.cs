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
using Project1.UI.ViewModels;

namespace Project1.UI.Controllers
{
    public class BusinessAccountsController : Controller
    {
        private static readonly decimal defaultInterestRate = 0.01m;
        private readonly IBusinessRepo _repo;
        private readonly UserManager<AppUser> userManager;

        public BusinessAccountsController(IBusinessRepo repo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            this.userManager = userManager;
        }

        // GET: BusinessAccounts
        
        public async Task<IActionResult> Index()
        {
            return View((await _repo.Get()).Where<BusinessAccount>(b => b.UserId == userManager.GetUserId(User)));
        }

        // GET: BusinessAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,UserId,Balance,InterestRate,IsClosed,DateCreated,NickName")] BusinessAccount businessAccount)
        {
            businessAccount.UserId = userManager.GetUserId(User);
            businessAccount.DateCreated = DateTime.Now;
            businessAccount.InterestRate = defaultInterestRate;
            if (ModelState.IsValid)
            {
                await _repo.Add(businessAccount);
                return RedirectToAction(nameof(Index));
            }
            return View(businessAccount);
        }

        //// GET: BusinessAccounts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var businessAccount = await _context.BusinessAccounts.FindAsync(id);
        //    if (businessAccount == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(businessAccount);
        //}

        //// POST: BusinessAccounts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Balance,InterestRate,IsClosed,DateCreated")] BusinessAccount businessAccount)
        //{
        //    if (id != businessAccount.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(businessAccount);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BusinessAccountExists(businessAccount.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(businessAccount);
        //}

        // GET: BusinessAccounts/Close/5
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

        // POST: BusinessAccounts/Close/5
        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseConfirmed(int id)
        {
            await _repo.Close(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bAccount = await _repo.Get(id);
            DepositVM depositVM = new DepositVM{Amount = 0};

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
                    await _repo.Deposit(id, depositVM.Amount);
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
            var bAccount = await _repo.Get(id);
            WithdrawlVM withdrawlVM = new WithdrawlVM { Amount = 0 };

            if (bAccount == null)
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
                    await _repo.Withdraw(id, withdrawlVM.Amount);
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
            var bAccount = await _repo.Get(id);
            //TransferVM transferVM = new TransferVM { Amount = 0 };//, Accounts = (await _repo.Get()).Where<Account>(b => b.UserId == userManager.GetUserId(User))};

            if (bAccount == null)
            {
                return NotFound();
            }


            //return RedirectToAction(nameof(Index));
            var allAccounts = (await _repo.Get()).Where(b => b.UserId == userManager.GetUserId(User));
            var accounts = allAccounts.Except(new List<BusinessAccount> { bAccount });
            return View(new TransferVM { Accounts = accounts, AccountIDFrom = (int)id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(int id, [Bind("AccountIDFrom, AccountIDTo, Amount")] TransferVM transferVM)
        {
            //transferVM.Accounts = new List<Account>();
            //if (ModelState.IsValid)
            //{
                try
                {
                    await _repo.Transfer(id, transferVM.AccountIDTo, transferVM.Amount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAccountExists(id))
                    {
                        return NotFound();
                    } else if (!BusinessAccountExists(transferVM.AccountIDFrom))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //return View(transferVM);
        }



        private bool BusinessAccountExists(int id)
        {
            return _repo.BusinessAccountExists(id);
        }
    }
}
