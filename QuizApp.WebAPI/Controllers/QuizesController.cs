using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;

namespace QuizApp.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuizesController : ControllerBase
	{
		private readonly IBaseService<Quiz> baseService;

		public QuizesController(IBaseService<Quiz> baseService)
		{
			this.baseService = baseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var test = await baseService.GetAllAsync();
			return Ok(test);
		}
	}
}
