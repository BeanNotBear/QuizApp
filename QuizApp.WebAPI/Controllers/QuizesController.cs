using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Commons.Pagging;
using QuizApp.Business.Commons.ViewModels.QuizViewModel;
using QuizApp.Business.Services.BaseService;
using QuizApp.Business.Services.QuizService;
using QuizApp.Data.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace QuizApp.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuizesController : ControllerBase
	{
		private readonly IQuizService _quizService;
		private readonly IMapper _mapper;

		public QuizesController(IQuizService quizService, IMapper mapper)
		{
			_quizService = quizService;
			_mapper = mapper;
		}

		[HttpGet]
		//[Authorize]
		public async Task<IActionResult> GetAll()
		{
			var quizes = await _quizService.GetAllAsync();
			var result = _mapper.Map<IEnumerable<QuizViewModel>>(quizes);
			return Ok(result.Select(x => new { x.Id, x.Title, x.Description, x.Duration, x.IsActive }));
		}

		[HttpGet]
		[Route("spec")]
		//[Authorize]
		public async Task<IActionResult> GetItems([FromQuery] QuizSpecParam quizSpecParam)
		{
			Expression<Func<Quiz, bool>> filter = q => (
				(string.IsNullOrWhiteSpace(quizSpecParam.SearchByTitle) || q.Title.Contains(quizSpecParam.SearchByTitle)) &&
				(quizSpecParam.IsActive == null || q.IsActive == quizSpecParam.IsActive) &&
				(quizSpecParam.Duration == null || q.Duration == quizSpecParam.Duration)
			);

			Func<IQueryable<Quiz>, IOrderedQueryable<Quiz>>? orderBy = quizSpecParam.OrderBy?.ToLower() switch
			{
				"title" => quizSpecParam.IsDescending
					? query => query.OrderByDescending(q => q.Title)
					: query => query.OrderBy(q => q.Title),

				"duration" => quizSpecParam.IsDescending
					? query => query.OrderByDescending(q => q.Duration)
					: query => query.OrderBy(q => q.Duration),

				_ => null
			};

			var items = await _quizService.GetAsync(filter, orderBy, "QuizQuestions", quizSpecParam.PageNumber, quizSpecParam.PageSize);
			var result = _mapper.Map<PaginatedResult<QuizViewModel>>(items);

			return Ok(result);
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var quiz = await _quizService.GetByIdAsync(id);
			var result = new
			{
				Id = quiz.Id,
				Title = quiz.Title,
				Description = quiz.Description,
				Duration = quiz.Duration,
				IsActive = quiz.IsActive
			};
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddQuiz([FromBody] AddQuizViewModel addQuizViewModel)
		{
			var quiz = _mapper.Map<Quiz>(addQuizViewModel);
			await _quizService.AddAsync(quiz);
			return Ok();
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateQuiz([FromRoute] Guid id, [FromBody] UpdateQuizViewModel updateQuizViewModel)
		{
			var quiz = _mapper.Map<Quiz>(updateQuizViewModel);
			quiz.Id = id;
			var isUpdated = await _quizService.UpdateAsync(quiz);
			return Ok(isUpdated);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteQuiz([FromRoute] Guid id)
		{
			var isDeleted = await _quizService.DeleteAsync(id);
			return NoContent();
		}
	}
}