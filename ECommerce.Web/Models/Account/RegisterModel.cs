using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models.Account
{
    public class RegisterModel
    {
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
