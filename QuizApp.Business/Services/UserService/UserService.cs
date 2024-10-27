using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using QuizApp.Business.Commons.ViewModels;
using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.UnitOfWork;
using QuizApp.Business.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace QuizApp.Business.Services.UserService
{
	public class UserService : BaseService<User>, IUserService
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper, IConfiguration configuration) : base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_mapper = mapper;
			_configuration = configuration;
		}

		public async Task<TokenResponse> Login(LoginViewModel loginViewModel)
		{
			var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
			if (user != null)
			{
				var isCorrectPassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
				if (isCorrectPassword)
				{
					var token = GenerateToken(user);
					var tokenResponse = new TokenResponse { Token = token };
					return tokenResponse;
				}
			}
			return null;
		}

		private string GenerateToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
			  _configuration["Jwt:Audience"],
			  null,
			  expires: DateTime.Now.AddMinutes(120),
			  signingCredentials: credentials);
			var result = new JwtSecurityTokenHandler().WriteToken(token);
			return result;
		}

		public async Task<bool> RegisterUser(RegisterViewModel registerViewModel, string[] roles)
		{
			var user = _mapper.Map<User>(registerViewModel);
			// when register an new account active status is alway false.
			user.IsActive = false;
			var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

			if (identityResult.Succeeded)
			{
				// Add Roles
				if (roles != null && roles.Any())
				{
					identityResult = await _userManager.AddToRolesAsync(user, roles);

					if (identityResult.Succeeded)
					{
						return true;
					}
				}
			}
			return false;
		}

	}
}
