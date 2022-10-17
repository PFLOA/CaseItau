using System;
using System.Collections.Generic;
using System.Text;

namespace A4S.CaseItau.Domain.Response
{
    public class UsuarioResponse
    {
        public int Seguidores { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }

        public UsuarioResponse(int seguidores, string nome, string userName)
        {
            Seguidores = seguidores;
            Nome = nome;
            UserName = userName;
        }
    }
}
