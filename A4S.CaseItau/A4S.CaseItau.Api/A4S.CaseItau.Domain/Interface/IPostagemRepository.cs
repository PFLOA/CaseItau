using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace A4S.CaseItau.Domain.Interface
{
    public interface IPostagemRepository : IRepository<Postagem>
    {
        Task<IQueryable<Postagem>> BuscarPostagensPorHoraDia();
        Task<IQueryable<Postagem>> BuscarPostagensPorIdiomaPais();
    }
}
