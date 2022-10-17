using A4S.CaseItau.Core.Interfaces.Results;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using A4S.CaseItau.Core.Rest;
using System.Threading.Tasks;
using MediatR;
using System;

namespace A4S.CaseItau.Core
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApiController : Controller
    {
        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        public ApiController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected async Task<IActionResult> ExecutarAsync(Func<Task<object>> func)
        {
            try
            {
                var result = await func.Invoke();

                if (result != null)
                {
                    if (result is IOperationResultBase)
                    {
                        return await CreateActionResult(result);
                    }
                }

                return await Task.FromResult(new BadRequestObjectResult(new { Error = "O Retorno da Mensagem possui um tipo não mapeado, verigfique a response." }));
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                _logger.LogError(ex, "Exceção Lançada: ");
                return await Task.FromResult(new BadRequestObjectResult("Verifique o log para detalhes da Exceção."));
            }
        }
        private async Task<IActionResult> CreateActionResult(dynamic result)
        {
            Response.StatusCode = (int)result.ResultType;

            return await Task.FromResult(RestStatusHttp.ReturnStatus(result.ResultType, result));
        }
    }
}
