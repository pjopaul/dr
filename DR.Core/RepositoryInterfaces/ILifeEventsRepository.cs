﻿using DR.Core.Abstract;
using DR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Core.RepositoryInterfaces
{
    public interface ILifeEventsRepository : IDataRepository<LifeEvent>
    {
        IEnumerable<LifeEvent> GetLifeEventsCreatedByUser(int userId);
    }
}
