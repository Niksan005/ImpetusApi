using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Data
{
    public class UserMatchRelation
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public AppUser ModelUser { get; set; }
        public string IdMatch { get; set; }
        public Match ModelMatch { get; set; }
    }
}
