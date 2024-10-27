using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Commons.ViewModels;
using QuizApp.Business.Services.UserService;
using QuizApp.Data.Models;

namespace QuizApp.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;

		public AuthController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> RegisterStudent([FromBody] RegisterViewModel registerViewModel)
		{
			var studentRole = new string[] { "Student" };
			var isCreated = await _userService.RegisterUser(registerViewModel, studentRole);
			return Ok(isCreated);
		}

		[HttpPost]
		[Route("Admin/Register")]
		public async Task<IActionResult> RegiterAdmin([FromBody] RegisterViewModel registrationViewModel)
		{
			var adminRole = new string[] { "Admin" };
			var isCreated = await _userService.RegisterUser(registrationViewModel, adminRole);
			return Ok(isCreated);
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
		{
			var token = await _userService.Login(loginViewModel);
			return Ok(token);
		}
	}
}
