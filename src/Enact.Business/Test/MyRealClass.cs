using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Business.Test
{
    public class MyRealClass<SomethingWithAnID> where SomethingWithAnID : IHasAnId
    {

        public int GetId(SomethingWithAnID something)
        {
            return something.Id;
        }
    }
}
