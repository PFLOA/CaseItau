using A4S.CaseItau.Application.Handlers.Usuarios.Handler;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Infra.Repository;
using Microsoft.Extensions.Logging;
using A4S.CaseItau.Teste.Builder;
using A4S.CaseItau.Infra.Data;
using Moq;

namespace A4S.CaseItau.Teste.Mock.Handlers
{
    public class UsuarioHandlerMock
    {

        public static readonly Mock<ILogger<Usuario>> _loggerUsuario = new Mock<ILogger<Usuario>>();
        public static readonly Mock<ILogger<BuscarUsuariosTopSeguidoresHandler>> _loggerTopSeguidores = new Mock<ILogger<BuscarUsuariosTopSeguidoresHandler>>();

        public static readonly CaseItauTwitterContext _usuarioRepositoryMockContext = UsuarioBuilder.MockContext();

        public static readonly IUsuarioRepository _usuarioRepository = new UsuarioRepository(_usuarioRepositoryMockContext, _loggerUsuario.Object);

        public BuscarUsuariosTopSeguidoresHandler BuscarUsuariosTopSeguidoresHandlerMock() => new BuscarUsuariosTopSeguidoresHandler(_loggerTopSeguidores.Object, _usuarioRepository);

    }
}
