using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.MVC.Models
{
	public class SignUpModel
	{

		[Required(ErrorMessage = "Enter your first name")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Enter your last name")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Please Enter the Email")]
		[Display(Name = "Email address")]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please Enter the Password")]
		[DataType(DataType.Password)]
		[Compare("ConformPassword", ErrorMessage = "Password does not match")]
		public string? Password { get; set; }

		[Display(Name = "Password"), DataType(DataType.Password)]
		[Required(ErrorMessage = "Please Enter the ConformPassword  ")]
		public string? ConformPassword { get; set; }
	}
}
