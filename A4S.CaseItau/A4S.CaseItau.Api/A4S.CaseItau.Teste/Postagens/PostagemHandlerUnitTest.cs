using A4S.CaseItau.Application.Handlers.Postagens.Request;
using A4S.CaseItau.Teste.JSON.Response;
using A4S.CaseItau.Teste.Mock.Handlers;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using System.Collections.Immutable;
using A4S.CaseItau.Application.Handlers.Postagens.Response;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace A4S.CaseItau.Teste.Postagens
{
    public class PostagemHandlerUnitTest
    {

        private static readonly PostagemHandlersMock _postagemHandlerMock = new PostagemHandlersMock();

        [Fact]
        public async Task QuandoBuscarTodasPostagensDoBancoRetornarTodasSeparadasPorHoraDia()
        {
            var handle = _postagemHandlerMock.BuscarPostagensPorHoraDiaHandlerMock();

            var result = await handle.Handle(new BuscarPostagensPorHoraDiaRequest(), new CancellationToken());
            var expected = PostagensResponse.BuscarPostagensPorHoraDiaExpectedResponse();
            var expList = new List<Action<BuscarPostagensPorHoraDiaResponse>>();

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

        [Fact]
        public async Task QuandoBuscarTodasPostagensDoBancoRetornarTodasSeparadasPorIdioma()
        {
            var handle = _postagemHandlerMock.BuscarPostagensPorIdiomaPaisHandlerMock();

            var result = await handle.Handle(new BuscarPostagensPorIdiomaPaisRequest(), new CancellationToken());
            var expected = PostagensResponse.BuscarPostagensPorIdiomaExpectedResponse();
            var expList = new List<Action<BuscarPostagensPorIdiomaPaisResponse>>();

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
