using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Format For Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
