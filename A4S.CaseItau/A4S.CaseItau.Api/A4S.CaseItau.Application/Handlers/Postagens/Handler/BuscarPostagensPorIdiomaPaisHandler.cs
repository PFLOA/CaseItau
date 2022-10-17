using A4S.CaseItau.Application.Handlers.Postagens.Request;
using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Core.Interfaces.Results;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Core.Extensions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using A4S.CaseItau.Core.Enum;
using A4S.CaseItau.Core;
using System.Threading;
using MediatR;
using System.Linq;

namespace A4S.CaseItau.Application.Handlers.Postagens.Handler
{
    public class BuscarPostagensPorIdiomaPaisHandler : RequestHandlerExtension, IRequestHandler<BuscarPostagensPorIdiomaPaisRequest, IOperationResult<List<BuscarPostagensPorIdiomaPaisResponse>>>
    {
        private readonly IPostagemRepository _postagemRepository;

        public BuscarPostagensPorIdiomaPaisHandler(ILogger<BuscarPostagensPorHoraDiaHandler> logger, IPostagemRepository postagemRepository) : base(logger)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task<IOperationResult<List<BuscarPostagensPorIdiomaPaisResponse>>> Handle(BuscarPostagensPorIdiomaPaisRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler<List<BuscarPostagensPorIdiomaPaisResponse>>(async () =>
            {

                var postagens = await _postagemRepository.BuscarPostagensPorIdiomaPais();

                return await Task.FromResult(OperationResult<List<BuscarPostagensPorIdiomaPaisResponse>>.Create(EnumTypeResult.Ok, SepararIdioma(postagens.ToList())));
            });

        private List<BuscarPostagensPorIdiomaPaisResponse> SepararIdioma(List<Postagem> postagens)
        {
            List<BuscarPostagensPorIdiomaPaisResponse> list = new List<BuscarPostagensPorIdiomaPaisResponse>();
            BuscarPostagensPorIdiomaPaisResponse obj = new BuscarPostagensPorIdiomaPaisResponse();

            IEnumerable<string> idiomas = postagens.GroupBy(p=> p.Idioma).Select(p => p.First().Idioma);

            foreach (var idioma in idiomas)
            {
                IEnumerable<Postagem> postagIdiomas = postagens.Where(p => p.Idioma == idioma);

                obj.PostagemGrupos(postagIdiomas, idioma);

                list.Add(obj);

                obj = new BuscarPostagensPorIdiomaPaisResponse();
            }

            return list;
        }
    }
}
