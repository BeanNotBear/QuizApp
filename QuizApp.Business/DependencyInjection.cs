using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Business.Services.BaseService;

namespace QuizApp.Business
{
	public static class DependencyInjection
	{
		public static void AddBusinessService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
		}
	}
}
