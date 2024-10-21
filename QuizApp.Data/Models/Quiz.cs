using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Models
{
	public class Quiz
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }

		[Range(1, 3600)]
		public int Duration { get; set; }
		public ICollection<Question> Questions { get; set; }
	}
}
