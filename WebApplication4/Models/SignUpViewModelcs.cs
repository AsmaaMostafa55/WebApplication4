using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class SignUpViewModelcs
    {
        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Format For Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword Is Required")]
        public string ConfirmPassword {  get; set; }
        [Required(ErrorMessage = "Required To Agree")]
        public bool IsAgree { get; set; }

    }

}
