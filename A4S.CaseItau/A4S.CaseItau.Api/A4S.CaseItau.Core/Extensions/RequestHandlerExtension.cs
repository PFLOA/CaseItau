using A4S.CaseItau.Core.Interfaces.Results;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace A4S.CaseItau.Core.Extensions
{
    public class RequestHandlerExtension
    {
        protected readonly ILogger _logger;

        public RequestHandlerExtension(ILogger logger) => _logger = logger;

        protected async Task<IOperationResult<TResponse>> ExecutarHandler<TResponse>(Func<Task<IOperationResult<TResponse>>> func, Func<Exception, Task<IOperationResult<TResponse>>> error = null)
        {
			try
			{
                return await func.Invoke();
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Erro Interno do servidor:");

                if (error != null) return await error.Invoke(ex);

                return await Task.FromResult(OperationResultInternalError<TResponse>.Create<TResponse>().AddMessage("Verifique o log para detalhes da Exceção."));
			}

        }
    }
}
