using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.ViewModels.QuestionViewModel
{
	public class QuestionSpecParam
	{
		private const int MaxPageSize = 10;

		public string? SearchByContent { get; set; } = null;
		public bool? IsActive { get; set; } = null;
		public List<string> QuestionTypes { get; set; } = new List<string>();
        private int _pageNumber = 1;
		public int PageNumber
		{
			get => _pageNumber;
			set => _pageNumber = value <= 0 ? 1 : value;
		}

		private int _pageSize = 10;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
	}
}
