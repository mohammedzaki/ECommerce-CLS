using ECommerce.Core.Services.Abstractions;
using ECommerce.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AuthenticateRequest loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Authenticate(loginModel);
                if (result.Success)
                {
                    return Ok(result);
                }
                else 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                return NotFound(result);
            }
            return NotFound();

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterationModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterNewAccount(registerModel);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                return UnprocessableEntity(result);
            }
            return UnprocessableEntity();
        }
    }
}
