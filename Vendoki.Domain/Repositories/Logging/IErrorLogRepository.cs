using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendoki.Domain.Logging;

namespace Vendoki.Domain.Repositories.Logging
{
	public interface IErrorLogRepository
	{
		ErrorLog FindById(Guid errorLogId);
		long LogError(ErrorLog errorLog);
	}
}
