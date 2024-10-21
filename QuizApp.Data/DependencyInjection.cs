using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Data.Data;
using QuizApp.Data.Repositories.BaseRepository;
using QuizApp.Data.Repositories.UnitOfWork;

namespace QuizApp.Data
{
	public static class DependencyInjection
	{
		public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<QuizAppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
