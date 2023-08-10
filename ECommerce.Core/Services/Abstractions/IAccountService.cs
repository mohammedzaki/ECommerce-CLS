using ECommerce.Core.Services.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Abstractions
{
    public interface IAccountService
    {
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

        public Task<AuthenticateResponse> RegisterNewAccount(RegisterationModel model);
    }
}
