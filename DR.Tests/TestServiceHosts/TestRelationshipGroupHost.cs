using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using DR.Services.Contracts.ServiceContracts;

namespace DR.Tests.TestServiceHosts
{
    [TestClass]
    public class TestRelationshipGroupHost
    {

        [TestMethod]
        public void Test_RelationshipGroupManager_as_service()
        {

            ChannelFactory<IRelationshipGroupService> channelFactory =
                new ChannelFactory<IRelationshipGroupService>("");

            IRelationshipGroupService proxy = channelFactory.CreateChannel();

            ((ICommunicationObject)proxy).Open();

            channelFactory.Close();

        }
    }
}
