using DR.Data;
using DR.Services.Contracts.ServiceContracts;
using DR.Services.Managers;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM=System.ServiceModel;
using System.Diagnostics;

namespace DR.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            // Register your types, for instance:
            DataBootStraper.BootStrap(container);

            container.Register<IRelationshipGroupService,RelationshipGroupManager>();

            // Register the container to the SimpleInjectorServiceHostFactory.
            SimpleInjectorServiceHostFactory.SetContainer(container);

            Console.WriteLine("Starting up services...");
            Console.WriteLine("");

            //SM.ServiceHost host = new SM.ServiceHost(typeof(RelationshipGroupManager));

            var hostRelationshipGroupManager = new SimpleInjectorServiceHost(container, typeof(RelationshipGroupManager), new Uri[0]);
            var hostLifeEventManager = new SimpleInjectorServiceHost(container, typeof(LifeEventManager), new Uri[0]);


            StartService(hostRelationshipGroupManager, "Relationship Group");
            StartService(hostLifeEventManager, " LifeEvents ");

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();

            StopService(hostRelationshipGroupManager, "Relationship Group");
            StopService(hostLifeEventManager, "LifeEvents");

            Console.ReadLine();
        }

        static void StartService(SimpleInjectorServiceHost host, string serviceDescription)
        {
            host.Open();
            Console.WriteLine($"Service { serviceDescription } started");

            foreach (var endPoint in host.Description.Endpoints)
            {
                Console.WriteLine("Listening on endpoint:");
                Console.WriteLine($"Address: { endPoint.Address.Uri }");
                Console.WriteLine($"Binding: { endPoint.Binding.Name }");
                Console.WriteLine($"Contract: { endPoint.Contract.Name }");


            }
            Console.WriteLine();

        }

        static void StopService(SimpleInjectorServiceHost host, string serviceDescription)
        {
            host.Close();
            Console.WriteLine($"Service { serviceDescription } stopped");

            
            Console.WriteLine();

        }
    }
}
