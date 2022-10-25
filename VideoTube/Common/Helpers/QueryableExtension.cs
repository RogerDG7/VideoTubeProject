using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Common.Helpers;

public static class QueryableExtension
{
    public static  double TotalRow<T>(IQueryable<T> queryable, int numberOfRecords)
    {
        double count =  queryable.Count();
        double totalPages = Math.Ceiling(count / numberOfRecords);
        return totalPages;
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagination)
    {
        return queryable
               .Skip((pagination.CurrentPage - 1) * pagination.ItemsPerPage)
               .Take(pagination.ItemsPerPage);
    }
}
