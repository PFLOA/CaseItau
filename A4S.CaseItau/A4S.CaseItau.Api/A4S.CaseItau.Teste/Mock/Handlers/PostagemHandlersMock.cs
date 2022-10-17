using A4S.CaseItau.Application.Handlers.Postagens.Handler;
using Microsoft.Extensions.Configuration;
using A4S.CaseItau.Domain.Interface;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Infra.Repository;
using Microsoft.Extensions.Logging;
using A4S.CaseItau.Teste.Builder;
using A4S.CaseItau.Infra.Data;
using A4S.CaseItau.HTTP;
using Moq;

namespace A4S.CaseItau.Teste.Mock.Handlers
{
    public class PostagemHandlersMock
    {

        public static readonly Mock<ILogger<Postagem>> _loggerPostagem = new Mock<ILogger<Postagem>>();
        public static readonly Mock<ILogger<Usuario>> _loggerUsuario = new Mock<ILogger<Usuario>>();
        public static readonly Mock<ILogger<BuscarPostagensPorHoraDiaHandler>> _loggerHoraDia = new Mock<ILogger<BuscarPostagensPorHoraDiaHandler>>();
        public static readonly Mock<ILogger<ColetarDadosHandler>> _loggerColetarDados = new Mock<ILogger<ColetarDadosHandler>>();
        public static readonly Mock<IConfiguration> _configuration = ConfigurationBuild.MockContext();

        public static readonly CaseItauTwitterContext _postagemRepositoryMockContext = PostagemBuilder.MockContext();
        public static readonly CaseItauTwitterContext _usuarioRepositoryMockContext = UsuarioBuilder.MockContext();

        public static readonly PostagemRepository _postagemRepository = new PostagemRepository(_postagemRepositoryMockContext, _loggerPostagem.Object);
        public static readonly UsuarioRepository _usuarioRepository = new UsuarioRepository(_usuarioRepositoryMockContext, _loggerUsuario.Object);
        public static readonly ITwitterApi _twitterApi = new TwitterApi(_configuration.Object);


        public BuscarPostagensPorHoraDiaHandler BuscarPostagensPorHoraDiaHandlerMock() => new BuscarPostagensPorHoraDiaHandler(_loggerHoraDia.Object, _postagemRepository);
        public BuscarPostagensPorIdiomaPaisHandler BuscarPostagensPorIdiomaPaisHandlerMock() => new BuscarPostagensPorIdiomaPaisHandler(_loggerHoraDia.Object, _postagemRepository);
        public ColetarDadosHandler ColetarDadosHandlerMock() => new ColetarDadosHandler(_loggerColetarDados.Object, _usuarioRepository, _postagemRepository, _twitterApi);
    }
}
