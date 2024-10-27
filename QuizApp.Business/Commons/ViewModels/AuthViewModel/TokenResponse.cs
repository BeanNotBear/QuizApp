using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.ViewModels
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
