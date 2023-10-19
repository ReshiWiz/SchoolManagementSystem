using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.MVC.Models;
using SchoolManagementApp.MVC.Repository;

namespace SchoolManagementApp.MVC.Controllers;
public class AccountController : Controller
{
	private readonly IAccountRepository _accountRepository;
	public AccountController(IAccountRepository accountRepository)
	{
		_accountRepository = accountRepository;
	}
	public ActionResult SignUp()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> SignUp(SignUpModel model)
	{
		if (ModelState.IsValid)
		{
			var result = await _accountRepository.CreateUserAsync(model);

			if (!result.Succeeded)
			{
				foreach (var errorMessage in result.Errors)
				{
					ModelState.AddModelError("", errorMessage.Description);
				}
				return View(model);
			}
			ModelState.Clear();
		}
		return View(model);
	}
	public ActionResult Login()
	{
		return View();
	}
	[HttpPost]
	public async Task<ActionResult> Login(LoginModel model)
	{
		if (ModelState.IsValid)
		{
			var result = await _accountRepository.CreateUserLoginAsync(model);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			ModelState.AddModelError("", "Invalid Credentials");
		}
		return View(model);
	}

	public async Task<IActionResult> Logout()
	{
		await _accountRepository.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}
}