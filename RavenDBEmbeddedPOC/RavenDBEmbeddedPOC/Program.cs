using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace RavenDBEmbeddedPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var sub = new TestThingySub { Name = "Sub Thingy", widgetCount = 2 };
            var thingy = new TestThingy
            {
                Name = "Balls",
                SubThingy=sub,
                WidgetIDs = Enumerable.Range(0, 23).ToList()
            };
            thingy.SetId(342);

            TestThingy thing2;
            using (var documentStore = new EmbeddableDocumentStore { DataDirectory = @"C:\Users\Andrew\Dropbox\Code\Projects\RavenDBEmbeddedPOC\packages\RavenDB-Embedded.1.0.701\lib\net40" })
            {
                documentStore.Initialize();
                using (var session = documentStore.OpenSession())
                {
                    thing2 = (from t in session.Query<TestThingy>()
                                 select t).First();
                }
            }

            Console.WriteLine("we just ran this bitch");
            Console.Read();
        }
    }

    public class TestThingy
    {
        private int ID { get; set; }
        public string Name { get; set; }
        public List<int> WidgetIDs { get; set; }
        public TestThingySub SubThingy { get; set; }

        public void SetId(int id)
        {
            ID = id;
        }
    }

    public class TestThingySub
    {
        public string Name { get; set; }
        public int widgetCount { get; set; }
    }
}
