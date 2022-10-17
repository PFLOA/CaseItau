using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Application.Handlers.Postagens.Request;
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
using System;

namespace A4S.CaseItau.Application.Handlers.Postagens.Handler
{
    public class BuscarPostagensPorHoraDiaHandler : RequestHandlerExtension, IRequestHandler<BuscarPostagensPorHoraDiaRequest, IOperationResult<List<BuscarPostagensPorHoraDiaResponse>>>
    {
        private readonly IPostagemRepository _postagemRepository;

        public BuscarPostagensPorHoraDiaHandler(ILogger<BuscarPostagensPorHoraDiaHandler> logger, IPostagemRepository postagemRepository) : base(logger)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task<IOperationResult<List<BuscarPostagensPorHoraDiaResponse>>> Handle(BuscarPostagensPorHoraDiaRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler<List<BuscarPostagensPorHoraDiaResponse>>(async () =>
            {
                var postagens = await _postagemRepository.BuscarPostagensPorHoraDia();

                return await Task.FromResult(OperationResult<List<BuscarPostagensPorHoraDiaResponse>>.Create(EnumTypeResult.Ok, SepararHoraDia(postagens.ToList())));
            });

        private List<BuscarPostagensPorHoraDiaResponse> SepararHoraDia(List<Postagem> postagens)
        {
            List<BuscarPostagensPorHoraDiaResponse> list = new List<BuscarPostagensPorHoraDiaResponse>();
            var obj = new BuscarPostagensPorHoraDiaResponse();

            DateTime? controleData = null;

            postagens.ForEach(postag =>
            {
                if (controleData == null)
                {
                    controleData = postag.DataPostagem;
                    obj.DataHora = $"{postag.DataPostagem.ToString("dd/MM/yyyy-HH")}h";
                }

                if (controleData.Value.Day == postag.DataPostagem.Day)
                {
                    if (controleData.Value.Hour == postag.DataPostagem.Hour)
                    {
                        obj.AdicionarPostagemGrupo(postag);
                    }
                    else
                    {
                        list.Add(obj);

                        obj = new BuscarPostagensPorHoraDiaResponse();

                        obj.DataHora = $"{postag.DataPostagem.ToString("dd/MM/yyyy-HH")}";
                        obj.AdicionarPostagemGrupo(postag);

                        controleData = postag.DataPostagem;
                    }
                }
                else
                {
                    list.Add(obj);

                    obj = new BuscarPostagensPorHoraDiaResponse();

                    obj.DataHora = $"{postag.DataPostagem.ToString("dd/MM/yyyy-HH")}";
                    obj.AdicionarPostagemGrupo(postag);

                    controleData = postag.DataPostagem;
                }
            });

            return list;
        }

    }
}
