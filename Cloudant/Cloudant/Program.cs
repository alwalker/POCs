using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;

namespace Cloudant
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CouchClient("alwalker.cloudant.com", 443, "alwalker", "PASSWORD",
                true, AuthenticationType.Basic);
            var db = client.GetDatabase("cloudant-tutorial");

            Document untyped = db.GetDocument("966f8b38cba7a782899997c3487345ea");
            Thingy typed = db.GetDocument<Thingy>("966f8b38cba7a782899997c3487345ea");

            Console.WriteLine("balls");
            Console.ReadLine();
        }
    }

    class Thingy
    {
        public string player { get; set; }
        public string game { get; set; }
        public string score { get; set; }
    }
}
