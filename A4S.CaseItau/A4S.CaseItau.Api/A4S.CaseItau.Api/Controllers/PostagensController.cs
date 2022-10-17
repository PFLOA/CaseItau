using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Application.Handlers.Postagens.Request;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using A4S.CaseItau.Core;
using MediatR;

namespace A4S.CaseItau.Api.Controllers
{
    public class PostagensController : ApiController
    {
        public PostagensController(ILogger<PostagensController> logger, IMediator mediator) : base(logger, mediator) { }

        [SwaggerOperation(
            Summary = "Busca as postagens agrupadas por hora e dia.",
            Tags = new[] { "Endpoints Postagens" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Mapeamento de todos os tweets separados por hora e dia", typeof(OperationResult<BuscarPostagensPorHoraDiaResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(OperationResultInternalError<BuscarPostagensPorHoraDiaResponse>))]
        [HttpGet, Route("BuscarPostagensPorHoraDia")]
        public async Task<IActionResult> BuscarPostagensPorHoraDia() => await ExecutarAsync(async () => await _mediator.Send(new BuscarPostagensPorHoraDiaRequest()));

        [SwaggerOperation(
            Summary = "Busca as postagens agrupadas por idioma/pais.",
            Tags = new[] { "Endpoints Postagens" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Mapeamento de todos os tweets separados por idioma/pais", typeof(OperationResult<BuscarPostagensPorIdiomaPaisResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(OperationResultInternalError<BuscarPostagensPorIdiomaPaisResponse>))]
        [HttpGet, Route("BuscarPostagensPorIdiomaPais")]
        public async Task<IActionResult> BuscarPostagensPorIdiomaPais() => await ExecutarAsync(async () => await _mediator.Send(new BuscarPostagensPorIdiomaPaisRequest()));


        [SwaggerOperation(
            Summary = "Coleta determinadas postagens do Twitter, baseada em hashtags pre definidas.",
            Description = "Hashtags: #openbanking, #remediation, #devops, #sre, #microservices, #observality, #oauth, #metrics, #logmonitoring, #opentracing.",
            Tags = new[] { "Endpoints Postagens" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A coleta ocorreu sem erros", typeof(OperationResult<ColetarDadosResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(OperationResultInternalError<ColetarDadosResponse>))]
        [HttpGet, Route("ColetarDadosPreDefinidos")]
        public async Task<IActionResult> ColetarDadosPreDefinidos() => await ExecutarAsync(async () => await _mediator.Send(new ColetarDadosRequest()));
    }
}
