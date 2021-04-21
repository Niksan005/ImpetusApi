using ImpetusApi.Controllers.Data;
using ImpetusApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ImpetusApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLeaderboard : BaseController
    {

        public GetLeaderboard(ILogger<UserController> logger, ImpetusApiContext context)
            : base(logger, context)
        { }

        [HttpPost("getleaderboard")]
        public BaseInput<ICollection<Leaderboard>> Login()
        {
            BaseInput<ICollection<Leaderboard>> _output = new BaseInput<ICollection<Leaderboard>>();

            _context.Leaderboards.OrderByDescending(x => x.Points).Take(100);

            return _output;
        }
    }
}
