using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OldSamples
{
    public class Class1
    {
        [Fact]
        public void TestPass()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void TestFail()
        {
            Assert.Equal(4, 3 + 2);
        }

        [Fact]
        public void TestException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                throw new ArgumentException();
            });
        }
    }
}
