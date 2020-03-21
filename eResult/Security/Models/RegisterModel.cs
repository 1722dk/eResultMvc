using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IIT.EResult.Security.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Login { get; set; }

        private string _Email;
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage="Invalid email address!")]
        public string Email {
            get { return _Email; }
            set
            {
                _Email = value;
                Login = _Email;
            }
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PIN { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmed password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPIN { get; set; }
    }
}
