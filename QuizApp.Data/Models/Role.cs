using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
	public class Role : IdentityRole<Guid>
	{
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
