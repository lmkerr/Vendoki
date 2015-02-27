using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Base;

namespace Vendoki.Domain.Identity
{
	public class Role : BaseModel
	{
		public Guid RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
