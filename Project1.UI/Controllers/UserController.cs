using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project1.UI.ViewModels;
using Project1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project1.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(UserManager<AppUser> userManager,
                                  SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Details()
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            return View(currentUser);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    City = model.City,
                    State = model.State
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password,
                    model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
            }
            return View(model);
        }

        //public async Task<IActionResult> Edit()
        //{
        //    return View(await userManager.GetUserAsync(User));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit([Bind("FirstName, LastName, City, State, PhoneNumber")]AppUser appUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser currentUser = await userManager.GetUserAsync(User);
        //        currentUser.FirstName = appUser.FirstName;
        //        currentUser.LastName = appUser.LastName;
        //        currentUser.City = appUser.City;
        //        currentUser.State = appUser.State;
        //        currentUser.PhoneNumber = appUser.PhoneNumber;
        //        return RedirectToAction("Details", "User");
        //    }
        //    return View(appUser);
        //}
    }
}

