using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace First_API.Controllers
{
    [Route("")]
    [ApiController]
    public class HiController : ControllerBase
    {
        [HttpGet("hi")]
        public string Get(string v)
        {
            return "hello";
        }
    }

    [Route("hi/")]
    [ApiController]
    public class HiiWithParameterController : ControllerBase
    {
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return ("hello "+ name);
        }
    }
}
