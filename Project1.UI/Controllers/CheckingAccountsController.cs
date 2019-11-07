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

namespace Project1.UI.Controllers
{
    public class CheckingAccountsController : Controller
    {
        private static readonly decimal defaultInterestRate = 0.01m;
        private readonly Project1DbContext _context;
        private readonly UserManager<AppUser> userManager;

        public CheckingAccountsController(Project1DbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: CheckingAccounts

        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckingAccounts.Where(a => a.AppUserId == userManager.GetUserId(User)).ToListAsync());
        }

        // GET: CheckingAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingAccount = await _context.CheckingAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkingAccount == null)
            {
                return NotFound();
            }

            return View(checkingAccount);
        }

        // GET: CheckingAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: CheckingAccounts/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Balance,InterestRate,IsClosed,DateCreated,NickName")] CheckingAccount checkingAccount)
        {
            checkingAccount.AppUserId = userManager.GetUserId(User);
            checkingAccount.DateCreated = DateTime.Now;
            checkingAccount.InterestRate = defaultInterestRate;
            if (ModelState.IsValid)
            {
                _context.Add(checkingAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkingAccount);
        }

        // GET: CheckingAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingAccount = await _context.CheckingAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkingAccount == null)
            {
                return NotFound();
            }

            return View(checkingAccount);
        }

        // POST: CheckingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkingAccount = await _context.CheckingAccounts.FindAsync(id);
            _context.CheckingAccounts.Remove(checkingAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChekingAccountExists(int id)
        {
            return _context.CheckingAccounts.Any(e => e.Id == id);
        }
    }
}
