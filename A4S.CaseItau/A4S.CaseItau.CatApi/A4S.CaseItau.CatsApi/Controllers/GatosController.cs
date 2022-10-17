using A4S.CaseItau.Application.Handlers.Gatos.Response;
using A4S.CaseItau.Application.Handlers.Gatos.Request;
using A4S.CaseItau.Core.Interfaces.Results;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using A4S.CaseItau.Core;
using MediatR;

namespace A4S.CaseItau.CatsApi.Controllers
{
    public class GatosController : ApiController
    {
        public GatosController(ILogger<GatosController> logger, IMediator mediator) : base(logger, mediator) { }

        [SwaggerOperation(
            Summary = "Retorna todas as raças cadastradas no servidor, sem necessidade de parâmetro.",
            Tags = new[] { "Endpoints Pesquisa" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna todas as Raças de Gatos no servidor.", typeof(IOperationResult<BuscarRacasGatosResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(IOperationResultBase))]
        [HttpGet, Route("BuscarRacasGatos")]
        public async Task<IActionResult> BuscarRacasGatos() => await ExecutarAsync(async () => await _mediator.Send(new BuscarRacasGatosRequest()));

        [SwaggerOperation(
            Summary = "Busca raça de gato por id.",
            Tags = new[] { "Endpoints Pesquisa" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna Raça do gato por id.", typeof(IOperationResult<BuscarRacasGatosResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Raça do gato solicitada por id não encontrada.", typeof(IOperationResultBase))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(IOperationResultBase))]
        [HttpGet, Route("BuscarRacaGato/{id}")]
        public async Task<IActionResult> BuscarRacaGato([FromRoute] string id) => await ExecutarAsync(async () => await _mediator.Send(new BuscarRacaGatoRequest { Id = id }));

        [SwaggerOperation(
            Summary = "Busca raças de gatos que atendem os parâmetros passados, caso o parâmetro não seja preenchido todas as raças serão retornadas.",
            Tags = new[] { "Endpoints Pesquisa por Parâmetro" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Retornado com sucesso.", typeof(IOperationResult<BuscarRacasGatosResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não foram encontradas raças com o filtro passado.", typeof(IOperationResultBase))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(IOperationResultBase))]
        [HttpGet, Route("BuscarRacaGatoPorTemperamento/{temperamento}")]
        public async Task<IActionResult> BuscarRacasGatosPorTemperamento([FromRoute] string temperamento) => await ExecutarAsync(async () => await _mediator.Send(new BuscarRacasGatosRequest { Temperamento = temperamento }));

        [SwaggerOperation(
            Summary = "Busca raças de gatos que atendem os parâmetros passados, caso o parâmetro não seja preenchido todas as raças serão retornadas.",
            Tags = new[] { "Endpoints Pesquisa por Parâmetro" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Retornado com sucesso.", typeof(IOperationResult<BuscarRacasGatosResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Não foram encontradas raças com o filtro passado.", typeof(IOperationResultBase))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(IOperationResultBase))]
        [HttpGet, Route("BuscarRacasGatosPorOrigem/{origem}")]
        public async Task<IActionResult> BuscarRacasGatosPorOrigem([FromRoute] string origem) => await ExecutarAsync(async () => await _mediator.Send(new BuscarRacasGatosRequest { Origem = origem }));


        [SwaggerOperation(
            Summary = "Coleta informações da api de gatos, para alimentar o servidor.",
            Tags = new[] { "Endpoint Coleta de Dados" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Dados Coletados com sucesso.", typeof(IOperationResultBase))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Verifique o Log na ferramenta de centralização de Log Graylog.", typeof(IOperationResultBase))]
        [HttpGet, Route("ColetarDados")]
        public async Task<IActionResult> ColetarDados() => await ExecutarAsync(async () => await _mediator.Send(new ColetarRacasGatosRequest()));
    }
}
