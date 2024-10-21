namespace QuizApp.Data.Models
{
	public class Question
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public string QuestionType { get; set; }
		public bool IsActive { get; set; }
		public Guid QuizId { get; set; }
		public Quiz Quiz { get; set; }
		public ICollection<Answer> Answers { get; set; }
	}
}
