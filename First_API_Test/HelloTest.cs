using System;
using Xunit;
using FluentAssertions;
using First_API.Controllers;

namespace First_API_Test
{
    public class HelloTest
    {
        [Fact]
        public void Hello_Response()
        {
            HelloController valuesController = new HelloController();
            string result = valuesController.Get("Hello");
            result.Should().Be("Hii");
        }

        [Fact]
        public void Hello_With_Parater_Response()
        {
            HelloWithParameterController valuesController = new HelloWithParameterController();
            string result = valuesController.Get("Bhanu");
            result.Should().Be("hii Bhanu");
        }
    }
}
