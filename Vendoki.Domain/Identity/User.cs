using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Base;

namespace Vendoki.Domain.Identity
{
	public class User : BaseModel
	{
		public Guid UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Salt { get; set; }
	}
}
