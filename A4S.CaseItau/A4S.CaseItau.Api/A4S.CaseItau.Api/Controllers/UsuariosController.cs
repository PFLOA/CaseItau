using A4S.CaseItau.Application.Handlers.Usuarios.Response;
using A4S.CaseItau.Application.Handlers.Usuarios.Request;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using A4S.CaseItau.Core;
using MediatR;

namespace A4S.CaseItau.Api.Controllers
{
    public class UsuariosController : ApiController
    {
        public UsuariosController(ILogger<UsuariosController> logger, IMediator mediator) : base(logger, mediator) { }

        [SwaggerOperation(
            Summary = "Buscar os usuários com maior número de seguidores, baseado na amostra coletada.",
            Description = "Passe a quantidade de usuarios a serem retornados.",
            Tags = new[] { "Endpoints Usuarios" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Buscar os usuários com maior número de seguidores, baseado na amostra coletada.", typeof(OperationResult<BuscarUsuariosTopSeguidoresResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(OperationResultInternalError<BuscarUsuariosTopSeguidoresResponse>))]
        [HttpGet, Route("BuscarUsuariosTopSeguidores")]
        public async Task<IActionResult> BuscarUsuariosTopSeguidores([FromQuery] BuscarUsuariosTopSeguidoresRequest request) => await ExecutarAsync(async () => await _mediator.Send(request));
    }
}
