using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Commons.Pagging;
using QuizApp.Business.Commons.ViewModels.QuestionViewModel;
using QuizApp.Business.Services.QuestionService;
using QuizApp.Data.Models;
using System.Linq.Expressions;

namespace QuizApp.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private readonly IQuestionService questionService;
		private readonly IMapper mapper;

		public QuestionsController(IQuestionService questionService, IMapper mapper)
		{
			this.questionService = questionService;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var questions = await questionService.GetAllAsync();
			var questionViewModels = mapper.Map<IEnumerable<QuestionViewModel>>(questions);
			return Ok(questionViewModels);
		}

		[HttpGet]
		[Route("spec")]
		public async Task<IActionResult> GetItems([FromQuery] QuestionSpecParam questionSpecParam)
		{
			Expression<Func<Question, bool>> filter = q => (
				string.IsNullOrWhiteSpace(questionSpecParam.SearchByContent) || q.Content.Contains(questionSpecParam.SearchByContent) &&
				(questionSpecParam.IsActive == null || q.IsActive == questionSpecParam.IsActive) &&
				(!questionSpecParam.QuestionTypes.Any() || questionSpecParam.QuestionTypes.Contains(q.QuestionType))
			);

			var questions = await questionService.GetAsync(filter, null, "", questionSpecParam.PageNumber, questionSpecParam.PageSize);
			var result = mapper.Map<PaginatedResult<QuestionViewModel>>(questions);
			return Ok(result);
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var question = await questionService.GetByIdAsync(id);
			var questionViewModel = mapper.Map<QuestionViewModel>(question);
			return Ok(questionViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddQuestion([FromBody] AddQuestionViewModel addQuestionViewModel)
		{
			var question = mapper.Map<Question>(addQuestionViewModel);
			var isAdded = await questionService.AddAsync(question);
			return Ok(isAdded);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateQuestion([FromRoute] Guid id, [FromBody] UpdateQuestionViewModel updateQuestionViewModel)
		{
			var question = mapper.Map<Question>(updateQuestionViewModel);
			question.Id = id;
			var isUpdated = await questionService.UpdateAsync(question);
			return Ok(isUpdated);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteQuestion([FromRoute] Guid id)
		{
			var isdeleted = await questionService.DeleteAsync(id);
			return Ok(isdeleted);
		}
	}
}
