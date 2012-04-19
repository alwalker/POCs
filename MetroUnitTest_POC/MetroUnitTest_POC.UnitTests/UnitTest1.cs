using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroUnitTest_POC.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetroUnitTest_POC.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = 4;
            var blah = new MyClass { Number = 2 };

            var actual = blah.DoSomeMath(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var expected = 2;
            var blah = new MyClass { Number = 2 };

            var actual = blah.DoSomeMath(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var expected = 4;
            var blah = new MyClass { Number = 4 };

            var actual = blah.DoSomeMath(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var expected = 44;
            var blah = new MyClass { Number =4 };

            var actual = blah.DoSomeMath(11);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var expected = 6;
            var blah = new MyClass { Number = 2 };

            var actual = blah.DoSomeMath(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var expected = 10;
            var blah = new Class2 { Number = 5 };

            var actual = blah.DoSomeMath(2);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod7()
        {
            var expected = 5;
            var blah = new Class2 { Number = 2.5 };

            var actual = blah.DoSomeMath(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var expected = 1;
            var blah = new Class2 { Number = 1 };

            var actual = blah.DoSomeMath(1);

            Assert.AreEqual(expected, actual);
        }
    }
}
