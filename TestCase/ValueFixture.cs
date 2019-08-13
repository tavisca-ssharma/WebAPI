using System;
using Xunit;
using WebApplicationTest;
using System.Collections.Generic;

namespace TestCase
{
    public class ValueFixture
    {
        [Fact]
        public void HelloTest()
        {
            var controller = new WebApplicationTest.Controllers.ValuesController();
            var actualResult = controller.Get("Hello");
            Assert.Equal("Hey", actualResult.Value);
        }
        [Fact]
        public void HeyTest()
        {
            var controller = new WebApplicationTest.Controllers.ValuesController();
            var actualResult = controller.Get("Hey");
            Assert.Equal("Hello", actualResult.Value);
        }
    }
}
