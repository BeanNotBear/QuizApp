using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
	public class UserAnswer
	{
		public Guid Id { get; set; }
		public Guid UserQuizId { get; set; }
		public Guid QuestionId { get; set; }
		public Guid AnswerId { get; set; }
		public bool? IsCorrect { get; set; }
		public UserQuiz UserQuiz { get; set; }
		public Question Question { get; set; }
		public Answer Answer { get; set; }
	}
}
