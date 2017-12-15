using DR.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DR.Services.Contracts.ServiceContracts;
using DR.Core.Entities;
using DR.Core.RepositoryInterfaces;
using DR.Core.Common.Exceptions;
using System.ServiceModel;
using System.Security.Permissions;

namespace DR.Services.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class RelationshipGroupManager : ManagerBase, IRelationshipGroupService
    {
        private readonly IRelationshipGroupsRepository _relationshipGroupRepository;

        public RelationshipGroupManager(IRelationshipGroupsRepository dataRepository)
        {
            _relationshipGroupRepository = dataRepository;
        }

        //[PrincipalPermission(SecurityAction.Demand)]
        public RelationshipGroup[] GetAll()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IEnumerable<RelationshipGroup> rGroups = _relationshipGroupRepository.Get().ToList();
                return rGroups.ToArray();
            });
        }

        public RelationshipGroup GetById(int relationshipGroupId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var rGroupEntity = _relationshipGroupRepository.Get(relationshipGroupId);
                if (rGroupEntity == null)
                {
                    NotFoundException ex = new NotFoundException($"Relationship group with id { relationshipGroupId } not found");
                    //Throwing WCF FaultException won't fault proxy
                    //If we are throwing FaultException<T> then that T need mention in the service contract
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
                return rGroupEntity;
            });
        }

        public RelationshipGroup[] GetAllByUser(int userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IEnumerable<RelationshipGroup> rGroups = _relationshipGroupRepository.GetGroupsCreatedByUser(userId).ToList();
                return rGroups.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public RelationshipGroup UpdateGroup(RelationshipGroup rGroup)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                RelationshipGroup updateRelationshipGroup = null;
                if (rGroup.RelationshipGroupId == 0)
                {
                    updateRelationshipGroup = _relationshipGroupRepository.Add(rGroup);
                }
                else
                {
                    updateRelationshipGroup = _relationshipGroupRepository.Update(rGroup);
                }
                return updateRelationshipGroup;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteGroup(int relationshipGroupId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                _relationshipGroupRepository.Remove(relationshipGroupId);
            });
        }
    }
}
