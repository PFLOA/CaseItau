using A4S.CaseItau.Application.Handlers.Usuarios.Response;
using A4S.CaseItau.Application.Handlers.Usuarios.Request;
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
using System.Linq;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Usuarios.Handler
{
    public class BuscarUsuariosTopSeguidoresHandler : RequestHandlerExtension, IRequestHandler<BuscarUsuariosTopSeguidoresRequest, IOperationResult<List<BuscarUsuariosTopSeguidoresResponse>>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public BuscarUsuariosTopSeguidoresHandler(ILogger<BuscarUsuariosTopSeguidoresHandler> logger, IUsuarioRepository usuarioRepository) : base(logger) => 
            _usuarioRepository = usuarioRepository;

        public async Task<IOperationResult<List<BuscarUsuariosTopSeguidoresResponse>>> Handle(BuscarUsuariosTopSeguidoresRequest request, CancellationToken cancellationToken) =>
            await ExecutarHandler<List<BuscarUsuariosTopSeguidoresResponse>>(async () =>
			{
                var usuarios = await _usuarioRepository.BuscarTopUsuariosSeguidores(request.QtdUsuariosRetorno);

                return await Task.FromResult(OperationResult<List<BuscarUsuariosTopSeguidoresResponse>>
                    .Create(EnumTypeResult.Ok, usuarios.AsQueryable().ToListResponse<Usuario, BuscarUsuariosTopSeguidoresResponse>(p => p)));
            });
        
    }
}
