using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Application.Handlers.Postagens.Request;
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

namespace A4S.CaseItau.Application.Handlers.Postagens.Handler
{
    public class ColetarDadosHandler : RequestHandlerExtension, IRequestHandler<ColetarDadosRequest, IOperationResultBase>
    {
        private readonly ITwitterApi _twitterApi;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPostagemRepository _postagemRepository;

        public ColetarDadosHandler(ILogger<ColetarDadosHandler> logger, IUsuarioRepository usuarioRepository, IPostagemRepository postagemRepository, ITwitterApi twitterApi) : base(logger)
        {
            _twitterApi = twitterApi;
            _usuarioRepository = usuarioRepository;
            _postagemRepository = postagemRepository;
        }

        public async Task<IOperationResultBase> Handle(ColetarDadosRequest request, CancellationToken cancellationToken)
        {
            return await ExecutarHandler(async () =>
            {
                List<Usuario> usuarios = new List<Usuario>();
                List<Postagem> postagens = new List<Postagem>();

                ColetarDadosResponse coletarDadosResponse = ColetarDadosResponse.Create(5);

                foreach (var item in request.HashTags)
                {
                    var postuser = await _twitterApi.PostagensUsuariosRetorno(item);

                    usuarios.AddRange(postuser.Usuarios);
                    postagens.AddRange(postuser.Postagens);

                    coletarDadosResponse.AdicionarPostagens(postuser.Postagens);
                    coletarDadosResponse.AdicionarUsuarios(postuser.Usuarios);
                }

                await _usuarioRepository.Criar(usuarios);
                await _postagemRepository.Criar(postagens);

                return await Task.FromResult(OperationResult<ColetarDadosResponse>.Create(EnumTypeResult.Ok, coletarDadosResponse).AddMessage("Dados Coletados Com Sucesso !"));
            });
        }
    }
}
