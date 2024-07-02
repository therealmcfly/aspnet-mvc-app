using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_mvc_app.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match")]
		[Display(Name = "Confirm Password")]
		public string? ConfirmPassword { get; set; }
	}
}