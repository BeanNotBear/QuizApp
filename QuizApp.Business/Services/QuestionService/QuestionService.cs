using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services.QuestionService
{
	public class QuestionService : BaseService<Question>, IQuestionService
	{
		public QuestionService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
