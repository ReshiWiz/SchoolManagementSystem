using Microsoft.AspNetCore.Identity;
using SchoolManagementApp.MVC.Models;

namespace SchoolManagementApp.MVC.Repository
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public async Task<IdentityResult> CreateUserAsync(SignUpModel model)
		{
			var user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Email,
				Email = model.Email,
			};
			var result = await _userManager.CreateAsync(user, model.Password);
			return result;
		}


		public async Task<SignInResult> CreateUserLoginAsync(LoginModel loginModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
			return result;
		}

		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
