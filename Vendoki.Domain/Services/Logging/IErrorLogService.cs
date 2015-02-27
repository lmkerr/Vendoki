using Vendoki.Domain.Logging;

namespace Vendoki.Domain.Services.Logging
{
	public interface IErrorLogService
	{
		long LogError(ErrorLog errorLog);
	}
}
