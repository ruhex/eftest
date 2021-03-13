using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test : ControllerBase
    {


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }
    }
}
