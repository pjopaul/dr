using DR.Core.Entities;
using DR.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Repositories
{
    public class LifeEventsRepository : DataRepositoryBase<LifeEvent>, ILifeEventsRepository
    {
        

        protected override LifeEvent AddEntity(LifeEventsDBContext dbContext, LifeEvent entity)
        {
            return dbContext.LifeEvents.Add(entity);
        }

        protected override IEnumerable<LifeEvent> GetEntities(LifeEventsDBContext dbContext)
        {
            return (from e in dbContext.LifeEvents
                    select e);

        }

        protected override LifeEvent GetEntity(LifeEventsDBContext dbContext, int id)
        {
            return (from e in dbContext.LifeEvents
                    where e.LifeEventId == id
                    select e).FirstOrDefault();
        }

        protected override LifeEvent UpdateEntity(LifeEventsDBContext dbContext, LifeEvent entity)
        {
            return (from e in dbContext.LifeEvents
                    where e.LifeEventId == entity.LifeEventId
                    select e).FirstOrDefault();
        }

        /*Custom methods for this repo */
        public IEnumerable<LifeEvent> GetLifeEventsCreatedByUser(int userId)
        {
            using (LifeEventsDBContext dbContext = new LifeEventsDBContext())
            {
                return (from e in dbContext.LifeEvents
                        where e.CreatedByUserId == userId
                        select e).ToList();
            }
        }
    }
}
