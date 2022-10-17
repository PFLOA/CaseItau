using A4S.CaseItau.Application.Handlers.Usuarios.Response;
using A4S.CaseItau.Application.Handlers.Usuarios.Request;
using A4S.CaseItau.Teste.Mock.Handlers;
using A4S.CaseItau.Teste.JSON.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System;
using Xunit;

namespace A4S.CaseItau.Teste.Usuarios
{
    public class UsuarioHandlerUnitTest
    {
        private static readonly UsuarioHandlerMock _usuariogemHandlerMock = new UsuarioHandlerMock();

        [Fact]
        public async Task QuandoBuscarTodasPostagensDoBancoRetornarTodasSeparadasPorIdioma()
        {
            var handle = _usuariogemHandlerMock.BuscarUsuariosTopSeguidoresHandlerMock();

            var result = await handle.Handle(new BuscarUsuariosTopSeguidoresRequest { QtdUsuariosRetorno = 5 }, new CancellationToken());
            var expected = UsuariosResponse.BuscarUsuariosTopSeguidoresExpectedResponse();
            var expList = new List<Action<BuscarUsuariosTopSeguidoresResponse>>();

            expected.ForEach(exp =>
            {
                expList.Add(r =>
                {
                    var expected = JsonConvert.SerializeObject(exp);
                    var result = JsonConvert.SerializeObject(r);

                    Assert.Equal(expected, result);
                });
            });

            Assert.Collection(result.Data, expList.ToArray());
        }
    }
}
