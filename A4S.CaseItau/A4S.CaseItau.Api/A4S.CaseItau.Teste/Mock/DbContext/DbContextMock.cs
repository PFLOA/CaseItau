using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using A4S.CaseItau.Infra.Data;
using System.Linq;
using Moq;

namespace A4S.CaseItau.Teste.Mock.DbContext
{
    public static class DbContextMock
    {

        public static DbSet<T> GetMockContext<T>(List<T> lista) where T : class => GetMockContexto<T>(lista);

        private static DbSet<T> GetQueryableMockDbSet<T>(IQueryable<T> queryable) where T : class
        {
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            dbSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(queryable.ToList().Add);

            return dbSet.Object;
        }

        private static DbSet<T> GetMockContexto<T>(List<T> lista) where T : class
        {
            var queryCampanha = GetQueryableModel<T>(lista);

            var mockDbSet = GetQueryableMockDbSet(queryCampanha);

            var mockContext = new Mock<CaseItauTwitterContext>();

            mockContext.Setup(c => c.Set<T>()).Returns(mockDbSet);

            return mockDbSet;
        }

        private static IQueryable<T> GetQueryableModel<T>(List<T> lista) where T : class
        {
            return lista.AsQueryable();
        }
    }
}
