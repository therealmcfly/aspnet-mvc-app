using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_mvc_app.Dtos.Accounts;
using aspnet_mvc_app.Models;
using aspnet_mvc_app.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_mvc_app.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(loginVM.Email!);

				if (user != null)
				{
					var result = await _signInManager.CheckPasswordSignInAsync(user, loginVM.Password!, false);

					if (result.Succeeded)
					{
						if (user.Activated == true)
						{
							await _signInManager.SignInAsync(user, new AuthenticationProperties
							{
								IsPersistent = loginVM.RememberMe
							});

							return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Home");
						}
						else
						{
							ModelState.AddModelError("", user.Activated == null ? "Account not activated yet" : "Account inactive");
						}
					}
					else
					{
						ModelState.AddModelError("", "Invalid login attempt.");
					}
				}
				else
				{
					ModelState.AddModelError("", "Invalid account.");
				}
			}
			return View(loginVM);
		}

		public IActionResult Register(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerVM, string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = new AppUser
				{
					FirstName = registerVM.FirstName!,
					LastName = registerVM.LastName!,
					UserName = registerVM.Email!,
					Email = registerVM.Email!
				};

				var result = await _userManager.CreateAsync(user, registerVM.Password!);

				if (result.Succeeded)
				{
					// uncomment the code below if you want to automatically sign in the user after registration
					// await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(registerVM);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}