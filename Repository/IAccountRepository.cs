using Microsoft.AspNetCore.Identity;
using SchoolManagementApp.MVC.Models;

namespace SchoolManagementApp.MVC.Repository
{
	public interface IAccountRepository
	{
		Task<IdentityResult> CreateUserAsync(SignUpModel model);

		Task<SignInResult> CreateUserLoginAsync(LoginModel loginModel);
		Task SignOutAsync();
	}
}