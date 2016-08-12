
namespace Enact.Models.RepositoryInjection
{
    public interface ICrudRepository<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        bool MapType();
        void Create(TPrimaryObjectType item);
        TPrimaryObjectType Read(string id, bool includeVersion = true);                
        long Update(TPrimaryObjectType item, bool includeVersion = true);
        bool Delete(string id);
    }
}
