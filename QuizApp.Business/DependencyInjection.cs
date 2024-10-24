using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Business.Mappers;
using QuizApp.Business.Services.BaseService;
using QuizApp.Business.Services.UserService;
using QuizApp.Data.Data;
using QuizApp.Data.Models;

namespace QuizApp.Business
{
	public static class DependencyInjection
	{
		public static void AddBusinessService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentityCore<User>()
				.AddRoles<Role>()
				.AddEntityFrameworkStores<QuizAppDbContext>();
			services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
			services.AddAutoMapper(typeof(MapperProfile));
			services.AddScoped<IUserService, UserService>();
		}
	}
}
