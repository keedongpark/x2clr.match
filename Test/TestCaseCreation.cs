﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using x2;

namespace Test
{
    [TestFixture]
    class TestCaseCreation
    {
        /// <summary>
        /// Test creation of a Case outside the holder Flow
        /// - The creator needs to know the owning flow
        /// - Flow.Add, Case.Setup need to be called manually
        /// </summary>
        [Test]
        public void TestDynamicCreation()
        {
            var f1 = new ConcurrentThreadFlow();
            var f2 = new ConcurrentThreadFlow();

            Hub.Instance
                .Attach(f1)
                .Attach(f2);

            // Case.Setup has a holder argument.

            Hub.Startup();

            var c1 = new TestCase();

            f1.Add(c1);
            c1.Setup(f1);

            Assert.IsTrue(Object.ReferenceEquals(f1, c1.Flow));

            Hub.Shutdown();
        }

        class TestCase : Case
        {

            protected override void Setup()
            {
                base.Setup();


            }
        }
    }
}
