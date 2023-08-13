using ECommerce.Core.Data;
using ECommerce.Core.Services.Abstractions;
using ECommerce.Core.Services.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var response = new AuthenticateResponse { Success = true };
            /*var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null) 
            {
                var valid = await _signInManager
                    .UserManager
                    .CheckPasswordAsync(user, model.Password);
                if (valid)
                    return response;
            }*/
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
                return response;

            response.Success = false;
            response.Errors.Add("Username or Password is wrong!");
            return response;
        }

        public async Task<AuthenticateResponse> RegisterNewAccount(RegisterationModel model)
        {
            var response = new AuthenticateResponse { Success = true };
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return response;
            }
            else
            {
                response.Success = false;
                foreach (var error in result.Errors)
                {
                    response.Errors.Add(error.Description);
                }
                return response;
            }
        }
    }
}
