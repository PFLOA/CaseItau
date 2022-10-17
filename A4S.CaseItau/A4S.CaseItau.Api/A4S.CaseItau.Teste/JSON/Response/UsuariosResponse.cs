using A4S.CaseItau.Application.Handlers.Usuarios.Response;
using A4S.CaseItau.Teste.JSON.Listas;
using System.Collections.Generic;

namespace A4S.CaseItau.Teste.JSON.Response
{
    public static class UsuariosResponse
    {
        public static List<BuscarUsuariosTopSeguidoresResponse> BuscarUsuariosTopSeguidoresExpectedResponse() =>
            RetornoListMockJson.RetornoList<BuscarUsuariosTopSeguidoresResponse>("./JSON/Response/topUsersResponse.json");

    }
}
