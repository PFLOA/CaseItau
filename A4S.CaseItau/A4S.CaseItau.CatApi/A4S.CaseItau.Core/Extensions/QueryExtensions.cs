using System.Collections.Generic;
using System.Linq;
using System;

namespace A4S.CaseItau.Core.Extensions
{
    public static class QueryExtensions
    {
        public static List<TResponse> ToListResponse<TModel, TResponse>(this IQueryable<TModel> query, Func<TModel, TResponse> func)
        {
            List<TResponse> responses = new List<TResponse>();

            foreach (var item in query)
            {
                responses.Add(func.Invoke(item));
            }

            return responses;
        }
    }
}
