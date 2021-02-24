using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Data
{
    public class Match
    {
        public string Id { get; set; }
        public ICollection<UserMatchRelation> Players { get; set; }
    }
}
