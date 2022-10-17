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
    public class PostagemRepository : Repository<Postagem, CaseItauTwitterContext, long>, IPostagemRepository
    {
        public PostagemRepository(CaseItauTwitterContext dbContext, ILogger<Postagem> logger) : base(logger, dbContext) { }

        public async Task<IQueryable<Postagem>> BuscarPostagensPorHoraDia()
        {
            return await Task.FromResult(Set.OrderBy(p => p.DataPostagem));
        }

        public async Task<IQueryable<Postagem>> BuscarPostagensPorIdiomaPais()
        {
            return await Task.FromResult(Set.OrderBy(p => p.Idioma));
        }
    }
}
