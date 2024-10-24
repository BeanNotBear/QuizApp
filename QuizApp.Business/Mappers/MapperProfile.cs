using AutoMapper;
using QuizApp.Business.Commons.ViewModels;
using QuizApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Mappers
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<RegisterViewModel, User>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
		}
	}
}
