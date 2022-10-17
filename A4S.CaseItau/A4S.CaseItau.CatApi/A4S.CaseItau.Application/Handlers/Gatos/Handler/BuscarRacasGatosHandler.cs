using A4S.CaseItau.Application.Handlers.Gatos.Response;
using A4S.CaseItau.Application.Handlers.Gatos.Request;
using A4S.CaseItau.Core.Interfaces.Results;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.Extensions.Logging;
using A4S.CaseItau.Core.Extensions;
using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;
using System.Threading.Tasks;
using A4S.CaseItau.Core;
using System.Threading;
using System.Linq;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Gatos.Handler
{
    public class BuscarRacasGatosHandler : RequestHandlerExtension, IRequestHandler<BuscarRacasGatosRequest, IOperationResult<List<BuscarRacasGatosResponse>>>
    {
        private readonly IRacaRepository _racaRepository;

        public BuscarRacasGatosHandler(ILogger<BuscarRacasGatosHandler> logger, IRacaRepository racaRepository) : base(logger) => 
            _racaRepository = racaRepository;

        public async Task<IOperationResult<List<BuscarRacasGatosResponse>>> Handle(BuscarRacasGatosRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler(async () =>
            {
                var racas = await _racaRepository.BuscarRacasGatosPorFiltro(request);

                if(racas.Count() == 0) return await Task.FromResult(OperationResult<List<BuscarRacasGatosResponse>>
                        .Create(EnumTypeResult.NotFound, racas.ToListResponse<Raca, BuscarRacasGatosResponse>(p => p))
                        .AddMessage("Não foram encontrados registros que correspondam a pesquisa"));

                return await Task.FromResult(OperationResult<List<BuscarRacasGatosResponse>>
                    .Create(EnumTypeResult.Ok, racas.ToListResponse<Raca, BuscarRacasGatosResponse>(p => p)));
            });
    }
}
