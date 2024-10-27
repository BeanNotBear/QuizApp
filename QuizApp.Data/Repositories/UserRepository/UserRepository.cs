using Microsoft.AspNetCore.Identity;
using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.UserRepository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{

		private readonly QuizAppDbContext _context;
		public UserRepository(QuizAppDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
