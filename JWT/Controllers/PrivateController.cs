using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    public class PrivateController : Controller
    {
        // GET api/private
        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "wow", "much", "passwords", "0xFF00AD", "doge", "hacker",
                "         ▄              ▄",
                "        ▌▒█           ▄▀▒▌ ",
                "        ▌▒▒█        ▄▀▒▒▒▐ ",
                "       ▐▄▀▒▒▀▀▀▀▄▄▄▀▒▒▒▒▒▐ ",
                "     ▄▄▀▒░▒▒▒▒▒▒▒▒▒█▒▒▄█▒▐ ",
                "   ▄▀▒▒▒░░░▒▒▒░░░▒▒▒▀██▀▒▌ ",
                "  ▐▒▒▒▄▄▒▒▒▒░░░▒▒▒▒▒▒▒▀▄▒▒▌",
                "  ▌░░▌█▀▒▒▒▒▒▄▀█▄▒▒▒▒▒▒▒█▒▐",
                " ▐░░░▒▒▒▒▒▒▒▒▌██▀▒▒░░░▒▒▒▀▄▌ ",
                " ▌░▒▄██▄▒▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▌ ",
                "▌▒▀▐▄█▄█▌▄░▀▒▒░░░░░░░░░░▒▒▒▐ ",
                "▐▒▒▐▀▐▀▒░▄▄▒▄▒▒▒▒▒▒░▒░▒░▒▒▒▒▌",
                "▐▒▒▒▀▀▄▄▒▒▒▄▒▒▒▒▒▒▒▒░▒░▒░▒▒▐ ",
                " ▌▒▒▒▒▒▒▀▀▀▒▒▒▒▒▒░▒░▒░▒░▒▒▒▌ ",
                " ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▒▄▒▒▐",
                "  ▀▄▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▄▒▒▒▒▌",
                "    ▀▄▒▒▒▒▒▒▒▒▒▒▄▄▄▀▒▒▒▒▄▀ ",
                "      ▀▄▄▄▄▄▄▀▀▀▒▒▒▒▒▄▄▀ ",
                "         ▒▒▒▒▒▒▒▒▒▒▀▀"
            };
        }
    }
}