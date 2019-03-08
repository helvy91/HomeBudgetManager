using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HomeBudgetManager.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string orderBy)
        {
            string[] orderElements = orderBy.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (orderElements.Length != 2)
            {
                throw new ArgumentException(nameof(orderBy), "Provided string is in a wrong format");
            }

            string propertyName = orderElements[0];
            string ordering = orderElements[1].ToLower();
            if (!new[] { "desc", "asc" }.Contains(ordering))
            {
                throw new ArgumentException(nameof(orderBy), "Provided string is in a wrong format");
            }

            var type = typeof(TSource);
            var property = type.GetProperty(propertyName, BindingFlags.IgnoreCase);
            if (property == null)
            {
                throw new ArgumentException(nameof(orderBy), "Provided string is in a wrong format");
            }

            var typeParameter = Expression.Parameter(type, "x");
            var propertyParameter = Expression.Property(typeParameter, property);
            var selector = Expression.Lambda(propertyParameter, new ParameterExpression[] { typeParameter });
            
            string orderMethodName = ordering == "asc" ? "OrderBy" : "OrderByDescending";
            var method = typeof(Queryable).GetMethods()
                .Where(x => x.Name == orderMethodName)
                .Where(x => x.GetParameters().Count() == 2)
                .Single();

            var genericMethod = method.MakeGenericMethod(type, property.PropertyType);
            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
        }
    }
}
