using System;
using System.Linq;
using Dapper;
using Vendoki.Domain.Identity;
using Vendoki.Domain.Repositories.Identity;
using Vendoki.Infrastructure.Common;

namespace Vendoki.Infrastructure.Repositories.Identity
{
	public class UserRepository : IUserRepository
	{
		private readonly DbConnectionFactory _factory;

		public UserRepository(DbConnectionFactory factory)
		{
			_factory = factory;
		}

		public User FindById(Guid userId)
		{
			try
			{
				const string query = @"SELECT
											[UserId],
											[Email],
											[CreatedById],
											[CreatedByOn],
											[CreatedByIp],
											[ModifiedById],
											[ModifiedOn],
											[ModifiedByIp]
									FROM User
									WHERE UserId = @UserId";

				using (var connection = _factory.GetConnection())
				{
					return connection.Query<User>(query, new
					{
						UserId = userId
					}).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				return new User();
			}
		}

		public IQueryable<User> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
