using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.BaseRepository;

namespace QuizApp.Data.Repositories.UserRepository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(QuizAppDbContext context) : base(context)
		{
		}
	}
}
