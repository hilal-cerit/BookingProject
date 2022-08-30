using BookingProject.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject.Common.DataAccess.EntityFramework
{

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {

        public async Task<TEntity> Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return entity;

            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
      
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }



        public async Task<TEntity> Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
               /* var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;*/
                context.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }








    }
}
