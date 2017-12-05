using System.Collections.Generic;
using DR.Core.Abstract;
using DR.Core.Entities;

namespace DR.Core.RepositoryInterfaces
{
    public interface IRelationshipGroupsRepository : IDataRepository<RelationshipGroup>
    {
        IEnumerable<RelationshipGroup> GetGroupsCreatedByUser(int userId);
    }
}