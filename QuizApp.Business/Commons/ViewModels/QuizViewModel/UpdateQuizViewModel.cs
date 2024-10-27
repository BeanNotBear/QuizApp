using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.ViewModels.QuizViewModel
{
	public class UpdateQuizViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public int Duration { get; set; }
	}
}
