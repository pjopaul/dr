using DR.Services.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DR.Core.Entities;
using System.ServiceModel;
using DR.Core.RepositoryInterfaces;
using DR.Core.Common.Exceptions;

namespace DR.Services.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
      ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LifeEventManager : ManagerBase, ILifeEventsService
    {
        private readonly ILifeEventsRepository _lifeEventsRepository;
        private readonly IUsersRepository _usersRepository;

        public LifeEventManager(ILifeEventsRepository lifeEventsRepository, IUsersRepository usersRepository)
        {
            _lifeEventsRepository = lifeEventsRepository;
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Overiding managebase class implementation of to get the logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        protected override User LoadLoggedUser(string userName)
        {
            User user = _usersRepository.Get(userName);

            if (user == null)
            {
                NotFoundException ex = new NotFoundException($"User not found for the user name { userName }");
                throw new FaultException<NotFoundException>(ex, ex.Message);

            }
            return user;

        }

        public IEnumerable<LifeEvent> GetLifeEventsCreatedByUser(string userName)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                
                //To retrieve only logged in users created lifeevents
                ValidateUser(userName);

                //User user = _usersRepository.Get(userName);

                //if (user == null)
                //{
                //    NotFoundException ex = new NotFoundException($"User not found for the user name { userName }");
                //    throw new FaultException<NotFoundException>(ex, ex.Message);

                //}


                IEnumerable<LifeEvent> lifeEvents = _lifeEventsRepository.GetLifeEventsCreatedByUser(_loggedInUser.UserId);

                return lifeEvents;
            });
        }
    }
}
