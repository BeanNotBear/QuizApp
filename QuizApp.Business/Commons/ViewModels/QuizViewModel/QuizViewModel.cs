using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.ViewModels.QuizViewModel
{
	public class QuizViewModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public int Duration { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
