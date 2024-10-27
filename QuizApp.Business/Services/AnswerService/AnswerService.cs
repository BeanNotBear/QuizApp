using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services.AnswerService
{
	public class AnswerService : BaseService<Answer>, IAnswerService
	{
		public AnswerService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
