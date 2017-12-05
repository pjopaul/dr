using DR.Core.Entities;
using DR.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Repositories
{
    public class UsersRepository : DataRepositoryBase<User>, IUsersRepository
    {
        protected override User AddEntity(LifeEventsDBContext dbContext, User entity)
        {
            return dbContext.Users.Add(entity);
        }

        protected override IEnumerable<User> GetEntities(LifeEventsDBContext dbContext)
        {
            return (from e in dbContext.Users
                    select e);

        }

        protected override User GetEntity(LifeEventsDBContext dbContext, int id)
        {
            return (from e in dbContext.Users
                    where e.UserId == id
                    select e).FirstOrDefault();
        }

        protected override User UpdateEntity(LifeEventsDBContext dbContext, User entity)
        {
            return (from e in dbContext.Users
                    where e.UserId == entity.UserId
                    select e).FirstOrDefault();
        }

        /*Custom methods for this specific Repository */
    }
}
