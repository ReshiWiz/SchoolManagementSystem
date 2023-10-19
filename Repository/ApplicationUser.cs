using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.MVC.Repository
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? DateOfBirth { get; set; }
	}
}
