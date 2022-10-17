using Microsoft.EntityFrameworkCore;
using A4S.CaseItau.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using A4S.CaseItau.Core.Models;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using System;

namespace A4S.CaseItau.Core.Infra
{
    public class Repository<TEntidade, TContext, TId> : IRepository<TEntidade> where TEntidade : Entity<TId> where TContext : DbContext where TId : IEquatable<TId>
    {
        protected DbSet<TEntidade> Set { get; private set; }
        protected TContext context;
        protected ILogger<TEntidade> _logger;

        public Repository(ILogger<TEntidade> logger, TContext dbContext)
        {
            _logger = logger;
            context = dbContext;
            Type tipo = typeof(TEntidade);
            MappingProperties(dbContext, tipo);
        }

        public async Task<Guid> Alterar(TEntidade entidade)
        {
            var result = Set.Update(entidade);
            await context.SaveChangesAsync();

            return result.Entity.Guid;
        }

        public async Task<TEntidade> BuscarPorGuid(Guid guid)
        {
            var result = Set.First(p => p.Guid == guid);

            return await Task.FromResult(result);
        }

        public async Task<TEntidade> Criar(TEntidade entidade)
        {
            var result = Set.Add(entidade);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task Criar(List<TEntidade> entidade)
        {
            foreach (var item in entidade)
            {
                var ent = Set.Find(item.Id);

                if (ent == null)
                {
                    Set.Add(item);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Remover(TEntidade entidade)
        {
            var result = Set.Remove(entidade);

            if (result is null) return false;
            await context.SaveChangesAsync();

            return true;
        }

        private void Comparator(Object fromObjeto, PropertyInfo propertyInfo, Type toObjeto)
        {
            var toObjetoName = toObjeto.Name;
            var found = toObjetoName == propertyInfo.Name ? propertyInfo : null;

            if (found != null)
                Set = propertyInfo.GetValue(fromObjeto) as DbSet<TEntidade>;
        }

        private void MappingProperties(Object fromObjeto, Type toObjeto)
        {
            foreach (var properties in fromObjeto.GetType().GetProperties())
            {
                Comparator(fromObjeto, properties, toObjeto);
            }
        }
    }
}
