﻿using AeroBook.Data;
using AeroBook.Models;
using AeroBook.Repository.IRepository;
using AeroBook.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AeroBook.Controllers
{
	public class AccountController : Controller
	{
		private readonly ILogger<AccountController> _logger;
		private readonly IAccountRepository _accountRepository;
		
		public AccountController(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public IActionResult Homepage()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(User user)
		{
			
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            if (ModelState.IsValid)
			{
				if (user.Password != user.ConfirmPassword)
				{
					return View();
				}
				 
				var userObj = new AeroBook.Data.Models.Account.User()
				{
					Name = user.Name,
					Email = user.Email,
					Password = hashedPassword,
				};
				
				return RedirectToAction("Login");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(User user)
		{
           var userObj =_accountRepository.Login(user.Email, user.Password);
			if (userObj != null)
			{
                bool isPasswordMatched = BCrypt.Net.BCrypt.Verify(user.Password, userObj.Password);
                if (isPasswordMatched)
                {
                    //To store the username in the session and using the usernam in layout to display login and log out
                    HttpContext.Session.SetString("UserName", "userObj.Email");
                    return RedirectToAction("HomePage");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Email or Password";
                    return View();
                }
            }
			ViewBag.ErrorMessage = "User not found";
			return View("Login","Home");
		}


        [HttpGet]
        public IActionResult LogOut()
        {
			HttpContext.Session.Clear();

            return View();
        }
    }
}