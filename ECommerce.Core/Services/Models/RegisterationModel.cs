using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Models
{
    public class RegisterationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Your Password")]
        [Compare(nameof(Password), ErrorMessage = "The password dosen't match!")]
        public string ConfirmPassword { get; set; }
    }
}
