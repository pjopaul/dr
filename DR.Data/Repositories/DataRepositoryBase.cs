using DR.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data.Repositories
{
    public abstract class DataRepositoryBase<T>:DataRepositoryBase<T,LifeEventsDBContext>
        where T:class, IEntityId, new()
    {
        
    }
}
