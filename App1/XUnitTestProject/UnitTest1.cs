using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 2;
            int b = 3;

            Assert.Equal(a, b);
        }
    }
}
