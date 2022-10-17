using A4S.CaseItau.Teste.Mock.DbContext;
using A4S.CaseItau.Teste.JSON.Listas;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Infra.Data;
using Moq;

namespace A4S.CaseItau.Teste.Builder
{
    public class PostagemBuilder
    {
        public static CaseItauTwitterContext MockContext()
        {
            var context = new CaseItauTwitterContext();

            context.Postagem = DbContextMock.GetMockContext<Postagem>(RetornoListMockJson.RetornoList<Postagem>("./JSON/Listas/postagemLista.json"));

            return context;
        }
    }
}
