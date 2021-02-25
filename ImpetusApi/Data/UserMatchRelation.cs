using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Data
{
    public class UserMatchRelation
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string IdUser { get; set; }
        public AppUser ModelUser { get; set; }
        public string IdMatch { get; set; }
        public Match ModelMatch { get; set; }
    }
}
