using AutoMapper;
using QuizApp.Business.Commons.Pagging;
using QuizApp.Business.Commons.ViewModels;
using QuizApp.Business.Commons.ViewModels.QuestionViewModel;
using QuizApp.Business.Commons.ViewModels.QuizViewModel;
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
			CreateMap<QuizViewModel, Quiz>().ReverseMap().ForMember(dest => dest.NumberOfQuestions, opt => opt.MapFrom(src => src.QuizQuestions.Count));
			CreateMap<PaginatedResult<QuizViewModel>, PaginatedResult<Quiz>>().ReverseMap();
			CreateMap<AddQuizViewModel, Quiz>().ReverseMap();
			CreateMap<UpdateQuizViewModel, Quiz>().ReverseMap();

			// for question
			CreateMap<QuestionViewModel, Question>().ReverseMap();
			CreateMap<PaginatedResult<QuestionViewModel>, PaginatedResult<Question>>().ReverseMap();
			CreateMap<AddQuestionViewModel, Question>().ReverseMap();
			CreateMap<UpdateQuestionViewModel, Question>().ReverseMap();
		}
	}
}
