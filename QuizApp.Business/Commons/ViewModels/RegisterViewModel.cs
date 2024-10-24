using System.ComponentModel.DataAnnotations;

namespace QuizApp.Business.Commons.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string DisplayName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
	}
}
