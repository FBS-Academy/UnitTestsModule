using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Repository
{
    public abstract class GenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        protected IQueryable<T> Trackable() => this.dbSet.AsQueryable();

        protected IQueryable<T> NoTrackable() => this.dbSet.AsNoTracking().AsQueryable();

        protected T InsertOrUpdate(T entity)
        {
            var updated = this.dbSet.Update(entity);

            if (updated.State == EntityState.Added)
                updated.Entity.CreatedDate = DateTime.Now;

            updated.Entity.LastUpdatedDate = DateTime.Now;

            return updated.Entity;
        }

        protected T Delete(T entity) => this.dbSet.Remove(entity).Entity;

        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        protected Task<int> SaveChanges() => this.dbContext.SaveChangesAsync();
    }
}
