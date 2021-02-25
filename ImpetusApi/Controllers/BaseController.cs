using ImpetusApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        protected readonly ImpetusApiContext _context;

        public BaseController(ILogger<BaseController> logger, ImpetusApiContext context)
        {
            _logger = logger;
            _context = context;
        }
        protected AppUser GetUserByString(string name)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.Username.Equals(name));
            return user;
        }
    }
}
