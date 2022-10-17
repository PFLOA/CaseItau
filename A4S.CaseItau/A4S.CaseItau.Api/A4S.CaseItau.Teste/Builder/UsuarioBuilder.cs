using A4S.CaseItau.Teste.Mock.DbContext;
using A4S.CaseItau.Teste.JSON.Listas;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Infra.Data;

namespace A4S.CaseItau.Teste.Builder
{
    public class UsuarioBuilder
    {
        public static CaseItauTwitterContext MockContext()
        {
            var context = new CaseItauTwitterContext();

            context.Usuario = DbContextMock.GetMockContext(RetornoListMockJson.RetornoList<Usuario>("./JSON/Listas/usuarioLista.json"));

            return context;
        }
    }
}
