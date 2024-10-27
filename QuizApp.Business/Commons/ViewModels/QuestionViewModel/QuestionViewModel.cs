using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.ViewModels.QuestionViewModel
{
	public class QuestionViewModel
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public string QuestionType { get; set; }
		public bool IsActive { get; set; }
	}
}
