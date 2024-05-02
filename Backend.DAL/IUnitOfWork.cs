using Backend.DAL.Repositories.Contracts;

namespace Backend.DAL
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Commits the changes made in the unit of work to the underlying database.
        /// </summary>
        void Commit();

        /// <summary>
        /// Asynchronously commits the changes made in the unit of work to the underlying database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Rolls back the changes made in the unit of work.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Asynchronously rolls back the changes made in the unit of work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the repository for the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>The repository for the specified entity type.</returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}
