﻿using ECommerce.Core.Services.Abstractions;
using ECommerce.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateRequest loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Authenticate(loginModel);
                if (result.Success)
                {
                    return Redirect("/");
                }
                else 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterNewAccount(registerModel);
                if (result.Success)
                {
                    return Redirect("/Account/Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }
    }
}
