using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DR.Core;
using DR.Core.Entities;
using DR.Data.Repositories;
using DR.Core.RepositoryInterfaces;
using DR.Services.Contracts;
using DR.Services.Managers;
using Moq;
using SimpleInjector;
using DR.Data;
using System.Security.Principal;
using System.Threading;

namespace DR.Tests.TestManagers
{
    [TestClass]
    public class TestRelationshipGroupManager
    {
        public static Container container;
        public User user;

        [TestInitialize]
        public void Initialize()
        {

            //Include the WCF security
            //GenericPrincipal principal = new GenericPrincipal(
            //    new GenericIdentity("ServiceUser"), new string[] { " RoleGroup"});
            //Thread.CurrentPrincipal = principal;

            
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            DataBootStraper.BootStrap(container);

            // 3. Verify your configuration
            container.Verify();

             user = new User() { UserId = 10, UserRoleId = UserRole.Admin, LoginName = "TestUser", Password = "test", IsActive = true };

        }

        [TestMethod]
        public void Test_UpdateGroup_add_new_group()
        {
            RelationshipGroup newRGroup = new RelationshipGroup();
            RelationshipGroup addedRGroup = new RelationshipGroup() { RelationshipGroupId = 10 };

            Mock<IRelationshipGroupsRepository> mockRelationshipGroupsRepo = new Mock<IRelationshipGroupsRepository>();
            mockRelationshipGroupsRepo.Setup(obj => obj.Add(newRGroup)).Returns(addedRGroup);

            RelationshipGroupManager manager = new RelationshipGroupManager(mockRelationshipGroupsRepo.Object);

            RelationshipGroup results = manager.UpdateGroup(newRGroup);

            Assert.IsTrue(results == addedRGroup);


        }

        [TestMethod]
        public void Test_UpdateGroup_update_existing_group()
        {
            RelationshipGroup existingRGroup = new RelationshipGroup() { RelationshipGroupId = 10 };

            RelationshipGroup updatedRGroup = new RelationshipGroup() { RelationshipGroupId = 10 };

            Mock<IRelationshipGroupsRepository> mockRelationshipGroupsRepo = new Mock<IRelationshipGroupsRepository>();
            mockRelationshipGroupsRepo.Setup(obj => obj.Update(existingRGroup)).Returns(updatedRGroup);


            RelationshipGroupManager manager = new RelationshipGroupManager(mockRelationshipGroupsRepo.Object);

            RelationshipGroup results = manager.UpdateGroup(existingRGroup);
            Assert.IsTrue(results == updatedRGroup);
        }
    }
}
