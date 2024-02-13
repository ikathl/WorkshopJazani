using System.Linq.Expressions;

namespace Jazani.Domain.Cores.Repositories
{
    public interface ICrudRepository<T, ID>
    {
        Task<IReadOnlyList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(ID id);
        Task<T> SaveAsync(T entity);
        Task<T?> FindAsync(
            Expression<Func<T, bool>> predicate,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> FindAllAsync(
            Expression<Func<T, bool>> predicate,
            List<Expression<Func<T, object>>> includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}

