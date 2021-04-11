using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpetusApi.Controllers.Data
{
    public class BaseInput<T>
    {
        public string Status { get; set; }
        public T Output { get; set; }
    }
}
