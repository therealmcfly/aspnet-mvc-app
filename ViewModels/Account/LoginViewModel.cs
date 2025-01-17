using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_mvc_app.Dtos.Accounts
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}
}