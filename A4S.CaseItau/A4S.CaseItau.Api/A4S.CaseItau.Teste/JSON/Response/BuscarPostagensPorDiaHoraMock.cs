using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Teste.JSON.Listas;
using System.Collections.Generic;

namespace A4S.CaseItau.Teste.JSON.Response
{
    public static class PostagensResponse
    {
        public static List<BuscarPostagensPorHoraDiaResponse> BuscarPostagensPorHoraDiaExpectedResponse() =>
            RetornoListMockJson.RetornoList<BuscarPostagensPorHoraDiaResponse>("./JSON/Response/diaHoraListaResponse.json");

        public static List<BuscarPostagensPorIdiomaPaisResponse> BuscarPostagensPorIdiomaExpectedResponse() =>
            RetornoListMockJson.RetornoList<BuscarPostagensPorIdiomaPaisResponse>("./JSON/Response/idiomaListaResponse.json");
    }
}
