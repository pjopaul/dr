using AutoMapper;
using DR.Core.Abstract;
using DR.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data
{
    public abstract class DataRepositoryBase<T, U> :  IDataRepository<T>
        where T : class, IEntityId, new()
        where U : DbContext, new()
    {
        protected abstract T AddEntity(U dbContext, T entity);
        protected abstract T UpdateEntity(U dbContext, T entity);

        protected abstract IEnumerable<T> GetEntities(U dbContext);
        protected abstract T GetEntity(U dbContext, int id);


        public T Add(T entity)
        {
            using (U dbContext = new U())
            {
                T newEntity = AddEntity(dbContext, entity);
                dbContext.SaveChanges();
                return newEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (U dbContext = new U())
            {
                return (GetEntities(dbContext)).ToArray().ToList();
            }
        }

        public T Get(int id)
        {
            using (U dbContext = new U())
            {
                return GetEntity(dbContext, id);
            }
        }

        public void Remove(T entity)
        {
            using (U dbContext = new U())
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            using (U dbContext = new U())
            {
                T entity = GetEntity(dbContext, id);
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U dbContext = new U())
            {
                T exitingEntity = UpdateEntity(dbContext, entity);
                // Mapper.Map<T,T>(entity, exitingEntity);
                dbContext.Entry(exitingEntity).CurrentValues.SetValues(entity);
                dbContext.SaveChanges();
                return exitingEntity;
            }
        }
    }
}
