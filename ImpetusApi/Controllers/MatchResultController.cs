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
    public class MatchResultController : BaseController
    {
        public MatchResultController(ILogger<UserController> logger, ImpetusApiContext context)
            : base(logger, context)
        { }

        [HttpPost("result")]
        public async Task<bool> MatchResult(ICollection<string> players)
        {
            PointsChanges(players);

            _context.Matchs.Add(new Match());
            var _match = _context.Matchs.Last();
            foreach (string player in players)
            {
                var _user = GetUserByString(player);
                _context.UserMatchRelations.Add(new UserMatchRelation
                {
                    ModelUser = _user,
                    IdUser = _user.Id,
                    ModelMatch = _match,
                    IdMatch = _match.Id
                });
                var _rellation = _context.UserMatchRelations.Last();
                _context.Users.FirstOrDefault(x => x.Equals(player)).MatchHistory.Add(_rellation);
                _match.Players.Add(_rellation);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        private void PointsChanges(ICollection<string> players)
        {
            AppUser player1 = GetUserByString(players.First());
            player1.Points += players.Count() + 1;
            UpdateLeaderBoard(player1);
            foreach (string player in players)
            {
                GetUserByString(player).Points -= 1;
            }

        }

        private void UpdateLeaderBoard(AppUser player)
        {
            _context.Leaderboards.Where(x => x.Name.Equals(player.Username)).FirstOrDefault().Points = player.Points;
        }

        [HttpPost("getmatch")]
        public Match GetMatch(string _id)
        {
            return _context.Matchs.Where(x => x.Id.Equals(_id)).FirstOrDefault();
        }
    }
}
