using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Logging;
using Vendoki.Domain.Repositories.Logging;
using Vendoki.Domain.Services.Logging;

namespace Vendoki.Infrastructure.Services.Logging
{
	public class ErrorLogService : IErrorLogService
	{
		private readonly IErrorLogRepository _errorLogRepository;
		public ErrorLogService(IErrorLogRepository errorLogRepository)
		{
			_errorLogRepository = errorLogRepository;
		}

		public long LogError(ErrorLog errorLog)
		{
			return _errorLogRepository.LogError(errorLog);
		}
	}
}
