using DR.Core.Common.Exceptions;
using DR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DR.Services.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface ILifeEventsService
    {
        [OperationContract]    
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<LifeEvent> GetLifeEventsCreatedByUser(string userName);
    }
}
