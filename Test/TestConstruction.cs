using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using x2;
using Couchbase;

namespace Test
{
    [TestFixture]
    class TestConstruction
    {
        [Test]
        public void TestAuth()
        {
            var config = new Couchbase.Configuration.Client.ClientConfiguration
            {
                Servers = new List<Uri>
                   {
                       new Uri("http://localhost:8091/")
                   }
            };

            ClusterHelper.Initialize(config);

            var flow = new ConcurrentThreadFlow();

            var cc = new Server.Client.ClientCase();
            var lc = new Server.Session.LoginCase(flow);
            var ac = new Server.Master.AuthCase();
            var udc = new Server.Couchbase.UserDatabaseCase("default");

            flow.Add(cc);
            flow.Add(lc);
            flow.Add(ac);
            flow.Add(udc);

            Hub.Instance
                .Attach(flow);

            Hub.Startup();

            Thread.Sleep(100);

            cc.RequestLogin("temp", "temp");

            while (!cc.HasLogin)
            {
                Thread.Sleep(10);
            } 

            Assert.IsTrue(cc.HasLogin);

            cc.RequestLogout();

            Hub.Shutdown();

            ClusterHelper.Close();
        }

        /// <summary>
        /// Match / Instance construction
        /// </summary>
        [Test]
        public void TestMatch()
        {

        }

        /// <summary>
        /// A very simple game play.
        /// </summary>
        [Test]
        public void TestPlay()
        {

        }
      
    }
}
