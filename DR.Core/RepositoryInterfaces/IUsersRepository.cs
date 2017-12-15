using DR.Core.Abstract;
using DR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Core.RepositoryInterfaces
{
    public interface IUsersRepository : IDataRepository<User>
    {
        User Get(string userName);

       // User Authenticate(string userName, string password);

    }
}
