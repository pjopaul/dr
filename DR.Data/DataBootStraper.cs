using SimpleInjector;
using DR.Data.Repositories;
using DR.Core.RepositoryInterfaces;
using DR.Core.Abstract;

namespace DR.Data
{
    public static class DataBootStraper
    {
        public static Container DataDIContainer;

        public static void BootStrap(Container container)
        {
            container.Register<IRelationshipGroupsRepository, RelationshipGroupsRepository>();
            container.Register<IUsersRepository, UsersRepository>();
            container.Register<ILifeEventsRepository, LifeEventsRepository>();
            container.Register<IDataRepositoryFactory, DataRepositoryFactory>();
            //var repositoryAssembly = typeof(RelationshipGroupsRepository).Assembly;

            //var registrations =
            //    from type in repositoryAssembly.GetExportedTypes()
            //    where type.Namespace == "DR.Data.Repositories"
            //    where type.GetInterfaces().Any()
            //    select new { Service = type.GetInterfaces().Single(), Implementation = type };

            //foreach (var reg in registrations)
            //{
            //    container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            //}

            DataDIContainer = container;

        }
        
    }
}
