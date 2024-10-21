using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
	public class QuizQuestion
	{
		public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
    }
}
