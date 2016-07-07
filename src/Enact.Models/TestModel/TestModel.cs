using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Models.TestModel
{
    public class TestModel : GenericMetadata
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }

        public static TestModel Fake(int? id = null)
        {
            var fake = GenericMetadata.Fake<TestModel>(id);
            fake.MyInt = 1234;
            fake.MyString = "Hello String";
            return fake;
        }
        public static List<TestModel> FakeList()
        {
            return new List<TestModel>()
            {
                TestModel.Fake(1),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake(),
                TestModel.Fake()
            };
        }
    }
}
