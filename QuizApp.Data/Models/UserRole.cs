using Microsoft.AspNetCore.Identity;

namespace QuizApp.Data.Models
{
	public class UserRole : IdentityUserRole<Guid>
	{
		public Role Role { get; set; }
		public User User { get; set; }
	}
}
