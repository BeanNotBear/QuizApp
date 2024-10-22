using QuizApp.Data.Models;
using QuizApp.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.UserRepository
{
	public interface IUserRepository : IGenericRepository<User>
	{
	}
}
