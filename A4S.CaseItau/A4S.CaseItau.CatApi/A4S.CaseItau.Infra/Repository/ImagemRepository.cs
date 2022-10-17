using Microsoft.EntityFrameworkCore.Internal;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using A4S.CaseItau.Core.Infra;
using A4S.CaseItau.Infra.Data;
using System.Threading.Tasks;

namespace A4S.CaseItau.Infra.Repository
{
    public class ImagemRepository : Repository<Imagem, CaseItauCatApiContext, long>, IImagemRepository
    {
        public ImagemRepository(ILogger<Imagem> logger, CaseItauCatApiContext dbContext) : base(logger, dbContext) { }

        public async Task SalvarEmMassa(List<Imagem> imagens)
        {
            _logger.LogWarning("Salvando Dados Em Massa ! {0}", imagens.Count);

            foreach (var item in imagens)
            {
                var raca = Set.FirstOr(p => p.IdImage == item.IdImage, null);

                if (raca == null)
                {
                    Set.Add(item);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
