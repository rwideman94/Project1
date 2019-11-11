using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Models.Repositories;
using Project1.UI.ViewModels;

namespace Project1.UI.Controllers
{
    public class TermDepositsController : Controller
    {
        private readonly IAccountRepo _AcctRepo;
        private readonly ITermDepositRepo _TermDepositRepo;
        private readonly UserManager<AppUser> UserManager;

        public TermDepositsController(ITermDepositRepo termDepositRepo, IAccountRepo acctRepo, UserManager<AppUser> userManager)
        {
            _AcctRepo = acctRepo;
            _TermDepositRepo = termDepositRepo;
            UserManager = userManager;
        }

        // GET: TermDeposits
        public async Task<IActionResult> Index()
        {
            return View(await _TermDepositRepo.Get(UserManager.GetUserId(User)));
        }

        // GET: TermDeposits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termDeposit = await _TermDepositRepo.Get(id);
            if (termDeposit == null)
            {
                return NotFound();
            }

            return View(termDeposit);
        }

        // GET: TermDeposits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermDeposits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,TermYears")] TermDeposit termDeposit)
        {
            if (ModelState.IsValid)
            {
                termDeposit.WithdrawlAmount = (termDeposit.Amount * TermDeposit.TDInterestRate) + termDeposit.Amount;
                for (int i = 1; i < termDeposit.TermYears; i++)
                {
                    termDeposit.WithdrawlAmount += termDeposit.WithdrawlAmount * TermDeposit.TDInterestRate;
                }
                termDeposit.DateCreated = DateTime.Now;
                termDeposit.AppUserId = UserManager.GetUserId(User);
                await _TermDepositRepo.Add(termDeposit);
                return RedirectToAction(nameof(Index));
            }
            return View(termDeposit);
        }

        public async Task<IActionResult> Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var termD = await _TermDepositRepo.Get(id);
            if (termD == null)
            {
                return NotFound();
            }
            TDWithdrawlVM TDWVM = new TDWithdrawlVM { 
                Accounts = await _AcctRepo.Get(UserManager.GetUserId(User)), 
                Withdrawn = termD.Withdrawn,
                maturityDate = termD.DateCreated.AddYears(termD.TermYears)
            };
            return View(TDWVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(int id, [Bind("WithdrawlToAccount, AccountID, Withdrawn")] TDWithdrawlVM TDWVM)
        {
            TermDeposit termD = await _TermDepositRepo.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    if (TDWVM.WithdrawlToAccount)
                    {
                        var account = await _AcctRepo.Get(TDWVM.AccountID);
                        await _TermDepositRepo.Withdraw(termD);
                        await _AcctRepo.TDDeposit(account, termD.WithdrawlAmount, termD.Id);
                    }
                    else
                    {
                        await _TermDepositRepo.Withdraw(termD);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermDepositExists(id))
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
            return View(TDWVM);
        }

        private bool TermDepositExists(int id)
        {
            return _TermDepositRepo.TermDepositExists(id);
        }
    }
}
