using DR.Core.Entities;
using DR.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Repositories
{
    public class RelationshipGroupsRepository : DataRepositoryBase<RelationshipGroup>, IRelationshipGroupsRepository
    {
        protected override RelationshipGroup AddEntity(LifeEventsDBContext dbContext, RelationshipGroup entity)
        {
            return dbContext.RelationshipGroups.Add(entity);
        }

        protected override IEnumerable<RelationshipGroup> GetEntities(LifeEventsDBContext dbContext)
        {
            return (from e in dbContext.RelationshipGroups
                    select e);

        }

        protected override RelationshipGroup GetEntity(LifeEventsDBContext dbContext, int id)
        {
            return (from e in dbContext.RelationshipGroups
                    where e.RelationshipGroupId == id
                    select e).FirstOrDefault();
        }

        protected override RelationshipGroup UpdateEntity(LifeEventsDBContext dbContext, RelationshipGroup entity)
        {
            return (from e in dbContext.RelationshipGroups
                    where e.RelationshipGroupId == entity.RelationshipGroupId
                    select e).FirstOrDefault();
        }

        /*Custom methods for this specific Repository */

        public IEnumerable<RelationshipGroup> GetGroupsCreatedByUser(int userId)
        {
            using (LifeEventsDBContext dbContext = new LifeEventsDBContext())
            {
                return (from e in dbContext.RelationshipGroups
                        where e.CreatedByUserId== userId
                            select e).ToList(); 
            }

        }
    }
}
