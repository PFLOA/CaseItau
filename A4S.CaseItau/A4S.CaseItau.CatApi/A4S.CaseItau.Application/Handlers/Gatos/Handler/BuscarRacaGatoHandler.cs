using A4S.CaseItau.Application.Handlers.Gatos.Response;
using A4S.CaseItau.Application.Handlers.Gatos.Request;
using A4S.CaseItau.Core.Interfaces.Results;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Core.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using A4S.CaseItau.Core.Enum;
using System.Threading;
using A4S.CaseItau.Core;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Gatos.Handler
{
    public class BuscarRacaGatoHandler : RequestHandlerExtension, IRequestHandler<BuscarRacaGatoRequest, IOperationResult<BuscarRacaGatoResponse>>
    {
        private readonly IRacaRepository _racaRepository;

        public BuscarRacaGatoHandler(ILogger<BuscarRacaGatoHandler> logger, IRacaRepository racaRepository) : base(logger) => 
            _racaRepository = racaRepository;

        public async Task<IOperationResult<BuscarRacaGatoResponse>> Handle(BuscarRacaGatoRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler<BuscarRacaGatoResponse>(async () =>
            {
                var raca = await _racaRepository.BuscarPorId(request.Id);

                if (raca == null) return await Task.FromResult(OperationResult<BuscarRacaGatoResponse>.Create(EnumTypeResult.NotFound));

                return await Task.FromResult(OperationResult<BuscarRacaGatoResponse>.Create(EnumTypeResult.Ok, new BuscarRacaGatoResponse(raca)));
            });
        
    }
}
