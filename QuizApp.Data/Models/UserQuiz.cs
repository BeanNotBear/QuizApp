using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
	public class UserQuiz
	{
        public Guid Id { get; set; }

		public string UserId { get; set; }
        public Guid QuizId { get; set; }
        public DateTime StartedAt { get; set; }
		public DateTime FinishedAt { get; set; }
        public User User { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
