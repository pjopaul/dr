using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using DR.Data.Repositories;
using DR.Core;
using DR.Core.RepositoryInterfaces;
using DR.Core.Abstract;
using System.Collections.Generic;
using DR.Core.Entities;
using System.Linq;
using Moq;
using DR.Data;
namespace DR.Tests.TestRepositories
{
    [TestClass]
    public class TestRelationshipGroupsRepoTest
    {

         public static Container container;

        [TestInitialize]
        public void Initialize()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            //container.Register<IRelationshipGroupsRepository, RelationshipGroupsRepository>(Lifestyle.Transient);
            container.Register<RepositoryTestClass>();

            //container.Register<IDataRepositoryFactory, DataRepositoryFactory>();

            DataBootStraper.BootStrap(container);

            // 3. Verify your configuration
            container.Verify();

           
        }

        [TestMethod]
        public void Test_DataRepositoryFactory_RelationshipGroup()
        {
            var userRepoObj = container.GetInstance<IDataRepositoryFactory>().GetDataRepository<IUsersRepository>();
            Assert.IsNotNull(userRepoObj);

        }


        [TestMethod]
        public void Test_Instantiate_Repository()
        {
            //Arrange


            //Act

            // 4. Use the container
            var relationshipGroupRepo = container.GetInstance<IRelationshipGroupsRepository>();

            //Assert

            Assert.IsInstanceOfType(relationshipGroupRepo, typeof(RelationshipGroupsRepository));
        }

        [TestMethod]
        public void Test_GetAllRelationshipGroups()
        {
            //Arrange
            var relationshipGroupRepo = container.GetInstance<IRelationshipGroupsRepository>();
            //Act
            IEnumerable<RelationshipGroup> rGroups = relationshipGroupRepo.Get();
            //Assert
            Assert.IsNotNull(rGroups);
            var rGroupslist = rGroups.ToList();
            Assert.IsTrue(rGroupslist.Count > 1);
        }

        [TestMethod]
        public void Test_DI_RelationshipGroup_Repository()
        {
            //Arrange

            

            

            RepositoryTestClass repoTest = container.GetInstance< RepositoryTestClass>();


            //Act
            IEnumerable<RelationshipGroup> rGroups = repoTest.GetRelationshipGroups();

            //Assert
            Assert.IsTrue(rGroups.Any());

            Console.WriteLine($"{ rGroups.Count() }");

        }

        [TestMethod]
        public void Test_Mock_RelationshipGroup_Repository()
        {
            //Arrange

            User user = new User() { UserId = 10, UserRoleId = UserRole.Admin, LoginName = "TestUser", Password = "test", IsActive = true };

            IList<RelationshipGroup> groups = new List<RelationshipGroup>()
            {
                new RelationshipGroup(){ CreatedByUserId=10, CreatedByUser = user, GroupDesc = "Test Group 1", RelationshipGroupId =100},
                new RelationshipGroup(){ CreatedByUserId=10, CreatedByUser = user, GroupDesc = "Test Group 2", RelationshipGroupId =101}

            };

            //Mock the repository
            Mock<IRelationshipGroupsRepository> mockGroupRepo = new Mock<IRelationshipGroupsRepository>();
            mockGroupRepo.Setup(obj => obj.Get()).Returns(groups);


            //Act
            IEnumerable<RelationshipGroup> rGroups = mockGroupRepo.Object.Get();

            //Assert
            Assert.IsTrue(rGroups.Count() == 2);

           
        }

       
        
        public  class RepositoryTestClass
        {
            private readonly IDataRepositoryFactory _repositoryFactory;

            //Out of box more than one public constructor won't work with simpleinjector
            //public RepositoryTestClass()
            //{
                
            //}
            public RepositoryTestClass(IDataRepositoryFactory repositoryFactory)
            {
                _repositoryFactory = repositoryFactory;
            }

            public IEnumerable<RelationshipGroup> GetRelationshipGroups()
            {
                return _repositoryFactory.GetDataRepository<IRelationshipGroupsRepository>().Get();
            }
        }
    }
}
