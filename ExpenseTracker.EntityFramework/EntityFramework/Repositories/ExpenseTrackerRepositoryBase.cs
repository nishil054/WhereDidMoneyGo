using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ExpenseTracker.EntityFramework.Repositories
{
    public abstract class ExpenseTrackerRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ExpenseTrackerDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ExpenseTrackerRepositoryBase(IDbContextProvider<ExpenseTrackerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ExpenseTrackerRepositoryBase<TEntity> : ExpenseTrackerRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ExpenseTrackerRepositoryBase(IDbContextProvider<ExpenseTrackerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
