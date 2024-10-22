using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.RoleRepository
{
	public class RoleRepository : GenericRepository<Role>, IRoleRepository
	{
		public RoleRepository(QuizAppDbContext context) : base(context)
		{
		}
	}
}
