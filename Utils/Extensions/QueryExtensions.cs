using System.Linq.Expressions;
using Login.Data.Enum;

namespace Login.Utils.Extensions;

public static class QueryExtensions
{
    /// <summary>
    /// Orders the queryable in ascending or descending order.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by the function that is represented by keySelector.</typeparam>
    /// <param name="query">A sequence of values to order.</param>
    /// <param name="keySelector">A function to extract a key from an element.</param>
    /// <param name="order">Sort order as in ascending or descending.</param>
    /// <returns>Sorted query.</returns>
    public static IQueryable<TSource> OrderByDynamic<TSource, TKey>(
        this IQueryable<TSource> query,
        Expression<Func<TSource, TKey>> keySelector,
        SortOrder order
    )
    {
        return order == SortOrder.Descending
            ? query.OrderByDescending(keySelector)
            : query.OrderBy(keySelector);
    }
}
