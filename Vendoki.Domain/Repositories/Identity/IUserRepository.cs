using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Identity;

namespace Vendoki.Domain.Repositories.Identity
{
	public interface IUserRepository
	{
		User FindById(Guid userId);
		IQueryable<User> GetAll();
	}
}
