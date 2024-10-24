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
		public async Task<IActionResult> RegisterStudent([FromBody] RegisterViewModel registerViewModel)
		{
			var studentRole = new string[] { "Student" };
			var isCreated = await _userService.RegisterUser(registerViewModel, studentRole);
			return Ok(isCreated);
		}
	}
}
