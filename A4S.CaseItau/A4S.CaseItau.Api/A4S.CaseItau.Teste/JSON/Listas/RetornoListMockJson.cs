using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace A4S.CaseItau.Teste.JSON.Listas
{
    public static class RetornoListMockJson
    {
        public static List<T> RetornoList<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            string retorno = "";

            while (reader.Peek() >= 0)
            {
                retorno += reader.ReadLine();
            }

            return JsonConvert.DeserializeObject<List<T>>(retorno);
        }
    }
}
