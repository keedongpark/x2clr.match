using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using x2;

namespace Test
{
    [TestFixture]
    class TestConstruction
    {
        [Test]
        public void TestAuth()
        {
            var flow = new ConcurrentThreadFlow();

            var cc = new Server.Client.ClientCase();
            var lc = new Server.Session.LoginCase(flow);
            var ac = new Server.Master.AuthCase();

            flow.Add(cc);
            flow.Add(lc);
            flow.Add(ac);

            Hub.Instance
                .Attach(flow);

            Hub.Startup();

            Thread.Sleep(100);

            cc.RequestLogin("temp", "temp");

            while (cc.Guid == 0 )
            {
                Thread.Sleep(10);
            }

            Assert.IsTrue(cc.HasLogin);

            cc.RequestLogout();

            Hub.Shutdown();
        }

        [Test]
        public void TestMatch()
        {

        }

        [Test]
        public void TestPlay()
        {

        }
    }
}
