using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Models.TestModel;
using Enact.Repository.Es;
using Enact.Repository.Es.Test;
using Enact.Repository.Sql.Test;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enact.Business.Test
{
    [SingletonDependency]
    public class TestModelManager : CrudManager<TestModel>
    {
        private ElasticSearchTestRepository _esTestRepository;

        public TestModelManager(ElasticSearchTestRepository esTestRepository) : base(esTestRepository)
        {
            _esTestRepository = esTestRepository;
        }

        public async Task<IEnumerable<TestModel>> GetMyData(List<int> myInts)
        {
            var testModels = await _esTestRepository.GetTestModelsByMyInts(myInts);
            return testModels;
        }

        public bool MapType()
        {
            return _esTestRepository.MapType();
        }
    }
}
