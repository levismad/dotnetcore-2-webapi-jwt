using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    public class PublicController : Controller
    {
        // GET api/public
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "some", "public", "data", "for", "u", "m8" };
        }
    }
}
