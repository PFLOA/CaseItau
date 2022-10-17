using System.Collections.Generic;
using A4S.CaseItau.Core.Models;

namespace A4S.CaseItau.Domain.Entidades
{
    public class Usuario : Entity<long>
    {
        public int Seguindo { get; set; }
        public int Seguidores { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Postagem> Postagens { get; set; }

        public Usuario() { }
        public Usuario(int seguindo, int seguidores, long id, string nome, string userName)
        {
            Id = id;
            Seguindo = seguindo;
            Seguidores = seguidores;
            Nome = nome;
            UserName = userName;
        }
    }
}
