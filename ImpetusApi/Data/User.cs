using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Data
{
    public class AppUser
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public ICollection<UserMatchRelation> MatchHistory { get; set; }

    }
}
