using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using x2;
using Couchbase;

namespace Test
{
    [TestFixture]
    class TestCouchbaseQuery
    {
        public class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }
        }


        [Test]
        public void TestBasicQuery()
        {
            Cluster cluster = new Cluster();

            using (var bucket = cluster.OpenBucket())
            {
                var document = new Document<Person>
                {
                    Id = "P1",
                    Content = new Person
                    {
                        FirstName = "John",
                        LastName = "Adams",
                        Age = 21
                    }
                };

                var result = bucket.Insert(document);

                if (result.Success)
                {
                    Console.WriteLine("Inserted document '{0}'", document.Id);

                    result = bucket.GetDocument<Person>("P1");
                    if (result.Success)
                    {
                        var person = result.Content;

                        Console.WriteLine(
                            "Retrieved document '{0}': {1} {2}", 
                            result.Id, person.FirstName, person.LastName
                        );
                    }
                } 
            } 
        }

        [Test]
        public void TestMultipleFlows()
        {
            // UserLoadCase
            // - Loading만 처리 

            // UserQueryCase
            // - 다른 쿼리들 처리 

        }
    }
}
