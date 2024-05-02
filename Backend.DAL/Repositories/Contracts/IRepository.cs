using System.Linq.Expressions;

namespace Backend.DAL.Repositories.Contracts
{
    /// <summary>
    /// Represents a generic repository interface.
    /// </summary>
    /// <typeparam name="T">Entity to be used in the repo.</typeparam>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T?> GetByIdAsync(object id);

        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(params T[] entities);

        void Delete(T entity);

        void DeleteRange(params T[] entities);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
