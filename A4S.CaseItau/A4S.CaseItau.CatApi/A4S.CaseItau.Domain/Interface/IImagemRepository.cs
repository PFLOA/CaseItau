using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A4S.CaseItau.Domain.Interface
{
    public interface IImagemRepository : IRepository<Imagem>
    {
        Task SalvarEmMassa(List<Imagem> imagens);
    }
}
