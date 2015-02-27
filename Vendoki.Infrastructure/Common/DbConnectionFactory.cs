using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Common;

namespace Vendoki.Infrastructure.Common
{
	public class DbConnectionFactory : IDbConnectionFactory
	{
		private readonly List<SqlConnection> _connectionList;
		private readonly string _connectionString;

		public DbConnectionFactory(string connectionString)
		{
			_connectionString = connectionString;
			_connectionList = new List<SqlConnection>();
		}

		public void Dispose()
		{
			var connectionList = _connectionList.Where(item => !item.Equals(null)).ToList();
			foreach (var sqlConnection in connectionList)
			{
				_connectionList.Remove(sqlConnection);
				sqlConnection.Dispose();
			}
		}

		public IDbConnection GetConnection()
		{
			var connection = new SqlConnection(_connectionString);
			connection.Open();
			_connectionList.Add(connection);
			return connection;
		}
	}
}
