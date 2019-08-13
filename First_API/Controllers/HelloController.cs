using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace First_API.Controllers
{
    [Route("")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet("hello")]
        public string Get(string id)
        {
            //if (id.Equals("Hello"))
            //    return "Hi";
            //else
            //    return "Say Hello..";
            return "Hii";
        }
    }
    [Route("hello/")]
    [ApiController]
    public class HelloWithParameterController : ControllerBase
    {
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return ("hii " + name);
        }
    }
}
