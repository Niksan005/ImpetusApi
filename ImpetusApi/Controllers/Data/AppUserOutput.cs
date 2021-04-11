using ImpetusApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Controllers.Data
{
    public class AppUserOutput
    {
        public AppUserOutput(AppUser _user)
        {
            UserName = _user.Username;
            Points = _user.Points;
        }

        public string UserName { get; set; }
        public int Points { get; set; }
        public List<string> MatchHistoryIDs { get; set; }
    }
}
