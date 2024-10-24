using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QuizApp.Business.Commons.ViewModels;
using QuizApp.Business.Services.BaseService;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services.UserService
{
	public class UserService : BaseService<User>, IUserService
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper) : base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<User> FindByUsernameAndPassword(string username, string password)
		{
			var query = _unitOfWork.UserRepository.GetQuery();
			var user = await query.FirstOrDefaultAsync(x => x.UserName == username && x.PasswordHash == password);
			if (user is null)
			{
				throw new Exception();
			}
			return user;
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
