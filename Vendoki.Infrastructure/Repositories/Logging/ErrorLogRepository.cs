using System;
using System.Linq;
using Dapper;
using Vendoki.Domain.Logging;
using Vendoki.Domain.Repositories.Logging;
using Vendoki.Infrastructure.Common;

namespace Vendoki.Infrastructure.Repositories.Logging
{
	public class ErrorLogRepository : IErrorLogRepository
	{
		private readonly DbConnectionFactory _factory;

		public ErrorLogRepository(DbConnectionFactory factory)
		{
			_factory = factory;
		}

		public ErrorLog FindById(Guid errorLogId)
		{
			try
			{
				const string query = @"SELECT
											[ErrorLogId],
											[Message],
											[InnerException],
											[CreatedById],
											[CreatedByOn],
											[CreatedByIp],
											[ModifiedById],
											[ModifiedOn],
											[ModifiedByIp]
									FROM User
									WHERE ErrorLogId = @ErrorLogId";

				using (var connection = _factory.GetConnection())
				{
					return connection.Query<ErrorLog>(query, new
					{
						ErrorLogId = errorLogId
					}).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				return new ErrorLog();
			}
		}


		public long LogError(ErrorLog errorLog)
		{
			try
			{
				const string query = @"INSERT INTO [ErrorLog]
											(ErrorLogId, Message, InnerException,
											CreatedById, CreatedOn, CreatedByIp)
										VALUES
											(NEWID(), @Message, @InnerException,
											@CreatedById, GetDate(), @CreatedByIP)
										SELECT CAST(SCOPE_IDENTITY() as bigint)";

				using (var connection = _factory.GetConnection())
				{
					return connection.Query<long>(query, new
					{
						Message = errorLog.Message,
						InnerException = errorLog.InnerException,
						CreatedById = errorLog.CreatedById,
						CreatedOn = errorLog.CreatedOn,
						CreatedByIp = errorLog.CreatedByIp
					}).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				//TODO the error log didn't work.... soooo what now?
				return 0;
			}
		}
	}
}
