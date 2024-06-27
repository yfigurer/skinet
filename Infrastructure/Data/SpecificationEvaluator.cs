using Core.Entities;
using Core.Specitifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntitiy> where TEntitiy : BaseEntity
    {
        public static IQueryable<TEntitiy> GetQuery(IQueryable<TEntitiy> inputQuery, ISpecification<TEntitiy> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}