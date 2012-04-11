using System;
using System.Collections.Generic;
using System.Linq;

namespace Enum_POC
{
    class Program
    {
        enum Things { Thing1 = 1, Thing2 = 2, Thing3 = 4, Thing4 = 8 };

        static void Main(string[] args)
        {
            var someThings = Things.Thing2 | Things.Thing4;
                        
            if ((someThings & Things.Thing1) == Things.Thing1)
            {
                Console.WriteLine("Thing1");
            }
            else
            {
                Console.WriteLine("no thing 1");
            }
            if ((someThings & Things.Thing2) == Things.Thing2)
            {
                Console.WriteLine("Thing2");
            }
            else
            {
                Console.WriteLine("no thing 2");
            }
            if ((someThings & Things.Thing3) == Things.Thing3)
            {
                Console.WriteLine("Thing3");
            }
            else
            {
                Console.WriteLine("no thing 3");
            }
            if ((someThings & Things.Thing4) == Things.Thing4)
            {
                Console.WriteLine("Thing4");
            }
            else
            {
                Console.WriteLine("no thing 4");
            }

            Console.ReadLine();
        }
    }
}
