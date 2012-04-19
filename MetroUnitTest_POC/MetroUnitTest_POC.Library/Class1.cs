using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroUnitTest_POC.Library
{
    public class MyClass
    {
        public string Name { get; set; }
        public double Number { get; set; }

        public double DoSomeMath(int anotherNumber)
        {
            return anotherNumber * Number;
        }       
    }
}
