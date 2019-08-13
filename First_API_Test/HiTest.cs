using System;
using Xunit;
using FluentAssertions;
using First_API.Controllers;

namespace First_API_Test
{
    public class HiTest
    {
        [Fact]
        public void Hi_Response()
        {
            HiController valuesController = new HiController();
            string result = valuesController.Get("hi");
            result.Should().Be("hello");
        }

        [Fact]
        public void Hi_With_Parater_Response()
        {
            HiiWithParameterController valuesController = new HiiWithParameterController();
            string result = valuesController.Get("Bhanu");
            result.Should().Be("hello Bhanu");
        }
    }
}
