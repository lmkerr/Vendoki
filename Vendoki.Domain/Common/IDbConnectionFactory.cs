using System;
using System.Data;

namespace Vendoki.Domain.Common
{
	public interface IDbConnectionFactory : IDisposable
	{
		IDbConnection GetConnection();
	}
}
