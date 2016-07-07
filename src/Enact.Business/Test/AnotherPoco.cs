using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Business.Test
{
    public class AnotherPoco : IHasAnId
    {
        public int Id { get; set; }

        public string HolyMoly { get; set; }

    }
}
