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
    public interface IRelationshipGroupService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RelationshipGroup GetById(int relationshipGroupId);

        [OperationContract]
        RelationshipGroup[] GetAll();

        [OperationContract]
        RelationshipGroup[] GetAllByUser(int userId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        RelationshipGroup UpdateGroup(RelationshipGroup rGroup);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteGroup(int relationshipGroupId);

    }
}
