using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
	public class Role : IdentityRole
	{
		public string Description { get; set; }
		public bool IsActive { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
