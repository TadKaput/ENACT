using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Business.Test
{
    public class MyPoco : IHasAnId
    {
        public int Id { get; set; }

        public int MyPropertySomething { get; set; }
        public bool IsThisReal { get; set; }
        public string MyString { get; set; }

    }
}
