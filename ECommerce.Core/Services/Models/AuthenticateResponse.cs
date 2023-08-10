using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Models
{
    public class AuthenticateResponse
    {
        public bool Success { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
