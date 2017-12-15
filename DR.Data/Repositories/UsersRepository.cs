using DR.Core.Common.Exceptions;
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

        public User Get(string userName)
        {
            using (LifeEventsDBContext dbContext = new LifeEventsDBContext())
            {
                return (from e in dbContext.Users
                        where e.LoginName == userName
                        select e).FirstOrDefault();
            }
        }

        //public User Authenticate(string userName, string password)
        //{
        //    if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //    {
        //        ArgumentException ex = new ArgumentException("User name or password canot be empty");
        //        throw ex;
        //    }


        //    var user = Get(userName);

        //    if(user == null)
        //    {
        //        NotFoundException ex = new NotFoundException($"User with name {userName } not found");
        //        throw ex;
        //    }

        //    if (user.Password != password)
        //    {
        //        NotFoundException ex = new NotFoundException($"Invalid password for the user {user.LoginName}");
        //        throw ex;
        //    }

        //    return user;

        //}
    }
}
