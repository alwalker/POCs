using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Samples
{
    public class SomeTests
    {
        [Fact]
        public void TestPass()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void TestFail()
        {
            Assert.Equal(4, 2 + 2);
            throw new Exception();
        }
    }
}
