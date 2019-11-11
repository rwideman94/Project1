using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Models.Loans;
using Project1.Models.Repositories;
using Project1.UI.ViewModels;

namespace Project1.UI.Controllers
{
    public class LoansController : Controller
    {
        private readonly IAccountRepo _AcctRepo;
        private readonly LoanRepo _loanRepo;
        private readonly UserManager<AppUser> UserManager;

        public LoansController(LoanRepo repo, IAccountRepo acctRepo, UserManager<AppUser> userManager)
        {
            _loanRepo = repo;
            UserManager = userManager;
            _AcctRepo = acctRepo;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            return View(await _loanRepo.Get(UserManager.GetUserId(User)));
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _loanRepo.Get(id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Principal")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.AppUserId = UserManager.GetUserId(User);
                loan.CreationDate = DateTime.Now;
                loan.Balance = loan.Principal + (loan.Principal * Loan.LoanInterestRate);
                await _loanRepo.Add(loan);
                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }

        public async Task<IActionResult> Payment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loan = await _loanRepo.Get(id);
            if (loan == null)
            {
                return NotFound();
            }
            LoanPaymentVM loanPaymentVM = new LoanPaymentVM { Accounts = await _AcctRepo.Get(UserManager.GetUserId(User)), PaidOff = loan.PaidOff };
            return View(loanPaymentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(int id, [Bind("PaymentFromAccount, AccountID, PaidOff, Amount")] LoanPaymentVM loanPaymentVM)
        {
            Loan loan = await _loanRepo.Get(id);
            loanPaymentVM.AccountBalance = (await _AcctRepo.Get(loanPaymentVM.AccountID)).Balance;
            loanPaymentVM.Accounts = await _AcctRepo.Get(UserManager.GetUserId(User));
            if (ModelState.IsValid)
            {
                try
                {
                    if (loanPaymentVM.PaymentFromAccount)
                    {
                        var account = await _AcctRepo.Get(loanPaymentVM.AccountID);
                        await _loanRepo.Pay(loan, loanPaymentVM.Amount);
                        await _AcctRepo.LoanWithdrawl(account, loanPaymentVM.Amount, loan.Id);
                    }
                    else
                    {
                        await _loanRepo.Pay(loan, loanPaymentVM.Amount);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(id))
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
            return View(loanPaymentVM);
        }

        public bool LoanExists(int id)
        {
            return _loanRepo.LoanExists(id);
        }
    }
}
