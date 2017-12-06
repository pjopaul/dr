using DR.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Data
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return (T) DataBootStraper
                .DataDIContainer
                .GetInstance(typeof(T));

        }
    }
}
