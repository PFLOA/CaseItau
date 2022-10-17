using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using A4S.CaseItau.Core.Infra;
using A4S.CaseItau.Infra.Data;
using System.Threading.Tasks;
using System.Linq;

namespace A4S.CaseItau.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario, CaseItauTwitterContext, long>, IUsuarioRepository
    {
        public UsuarioRepository(CaseItauTwitterContext dbContext, ILogger<Usuario> logger) : base(logger, dbContext) { }

        public async Task<List<Usuario>> BuscarTopUsuariosSeguidores(int qtdUsuariosPesquisa)
        {

            List<Usuario> top = new List<Usuario>();

            Set.OrderByDescending(p => p.Seguidores)
                 .Take(qtdUsuariosPesquisa)
                 .ToList().ForEach(u =>
                 {
                     if (!top.Exists(ur => ur.Nome == u.Nome)) top.Add(u);
                 });

            return await Task.FromResult(top);
        }
    }
}
