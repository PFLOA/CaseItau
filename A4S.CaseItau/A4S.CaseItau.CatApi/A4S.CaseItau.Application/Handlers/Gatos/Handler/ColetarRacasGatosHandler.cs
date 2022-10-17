using A4S.CaseItau.Application.Handlers.Gatos.Request;
using A4S.CaseItau.Core.Interfaces.Results;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Domain.Entidades;
using Microsoft.Extensions.Logging;
using A4S.CaseItau.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using A4S.CaseItau.Core.Enum;
using A4S.CaseItau.Core;
using System.Threading;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Gatos.Handler
{
    public class ColetarRacasGatosHandler : RequestHandlerExtension, IRequestHandler<ColetarRacasGatosRequest, IOperationResultBase>
    {
        private readonly IImagemRepository _imagemRepository;
        private readonly IRacaRepository _gatoRepository;
        private readonly ICatApi _catApi;

        public ColetarRacasGatosHandler(ILogger<ColetarRacasGatosHandler> logger, IRacaRepository gatoRepository, IImagemRepository imagemRepository, ICatApi catApi) : base(logger)
        {
            _imagemRepository = imagemRepository;
            _gatoRepository = gatoRepository;
            _catApi = catApi;
        }

        public async Task<IOperationResultBase> Handle(ColetarRacasGatosRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler<IOperationResultBase>(async () =>
            {
                List<Imagem> imagens = new List<Imagem>();

                var racasGatos = await _catApi.ColetarGatosApi();

                foreach (var item in racasGatos)
                {
                    imagens.AddRange(await _catApi.ColetarImagensGatos(item.Id));
                }

                await _gatoRepository.SalvarEmMassa(racasGatos);
                await _imagemRepository.SalvarEmMassa(imagens);

                return await Task.FromResult(OperationResult<IOperationResultBase>.Create(EnumTypeResult.Ok));
            });
    }
}
