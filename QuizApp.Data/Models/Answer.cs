namespace QuizApp.Data.Models
{
	public class Answer
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsActive { get; set; }
    }
}
