using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerAPIController : Controller
    {
        [HttpGet]
        public List<string> Get()
        {
            List<string> li = new List<string>();
            li.Add("xyz");
            li.Add("abc");
            li.Add("sumukh");
            return li;
        }
    }
}
