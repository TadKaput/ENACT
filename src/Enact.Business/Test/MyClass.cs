using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Business.Test
{
    public class MyClass
    {
        public string GetAString()
        {
            return "hello world";
        }

        public int GetMyID<T>(T something) where T : IHasAnId
        {
            return something.Id;
        }

        public static bool IsThisTheRealWorld()
        {
            return false;
        }

        public static void DoWork()
        {
            var mystuff = new MyClass();
            var myPoco = new MyPoco()
            {
                Id = 4
            };
            var anotherPoco = new AnotherPoco()
            {
                Id = 5
            };

            var id = mystuff.GetMyID(myPoco);
            var somethingId = mystuff.GetMyID(anotherPoco);
        }
    }
}
