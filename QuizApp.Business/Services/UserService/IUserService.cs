using QuizApp.Business.Commons.ViewModels;
using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;

namespace QuizApp.Business.Services.UserService
{
	public interface IUserService : IBaseService<User>
	{
		Task<TokenResponse> Login(LoginViewModel loginViewModel);
		Task<bool> RegisterUser(RegisterViewModel registerViewModel, string[] roles);
	}
}
