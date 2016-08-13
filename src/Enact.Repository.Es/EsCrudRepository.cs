using Enact.Models;
using Enact.Models.RepositoryInjection;
using Enact.Repository.Es.Test;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Repository.Es
{
    /// <summary>
    /// ElasticSearch CrudRepository
    /// </summary>
    public class EsCrudRepository<TPrimaryObjectType> : ICrudRepository<TPrimaryObjectType> where TPrimaryObjectType : GenericMetadata
    {
        private ElasticClient _clientInstance;

        public EsCrudRepository(RepositoryClient client)
        {
            _clientInstance = client.Instance;
        }

        public bool CreateIndex(string index, int? replicas, int? shards)
        {
            return RepositoryClient.CreateNewIndex(_clientInstance, index, replicas, shards);
        }

        public bool MapType()
        {
            var index = _clientInstance.ConnectionSettings.DefaultIndex;
            var request = new IndexExistsRequest(index);
            var myIndex = _clientInstance.IndexExists(request);
            if (!myIndex.Exists)
                CreateIndex(index, 1, 1);
            var results = _clientInstance.Map<TPrimaryObjectType>(map => map.AutoMap());
            return results.IsValid;
        }

        public void Create(TPrimaryObjectType item)
        {
            if (item == null)
                throw new NullReferenceException($"You cannot create a null { typeof(TPrimaryObjectType) } object");

            item.CreateDate = DateTime.Now;
            item.LastEditDate = DateTime.Now;

            var result = _clientInstance.Index(item);
            if (!result.IsValid)
                throw new NullReferenceException($"{ typeof(TPrimaryObjectType) } creation failed, reason: { result.ServerError.Error.Reason }");
        }

        public TPrimaryObjectType Read(string id, bool includeVersion = true)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("ID cannot be null");
            var item = _clientInstance.Get<TPrimaryObjectType>(id);
            if (item.Source == null)
                throw new Exception("Object not found");
            var result = item.Source;
            if (includeVersion)
                result.DataVersion = item.Version;
            return result;
        }

        public async Task<TPrimaryObjectType> ReadAsync(string id, bool includeVersion = true)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Error: ID cannot be null");
            var item = await _clientInstance.GetAsync<TPrimaryObjectType>(id);
            if (item.Source == null)
                throw new Exception($"Error: { typeof(TPrimaryObjectType) }, ID: { id } not found");
            var result = item.Source;
            if (includeVersion)
                result.DataVersion = item.Version;
            return result;
        }

        public IEnumerable<TPrimaryObjectType> GetAllByQuery(Func<QueryContainerDescriptor<TPrimaryObjectType>, QueryContainer> queryContainerDescriptor, int from = 0, int size = 9999, bool includeVersion = true)
        {
            var search = _clientInstance.Search<TPrimaryObjectType>(s => s
                .Query(queryContainerDescriptor)
                .From(from)
                .Size(size)
                .Version(includeVersion));
            return search.ToResponseCollection();
        }

        public async Task<IEnumerable<TPrimaryObjectType>> GetAllByQueryAsync(Func<QueryContainerDescriptor<TPrimaryObjectType>, QueryContainer> queryContainerDescriptor, int from = 0, int size = 9999, bool includeVersion = true)
        {
            var search = await _clientInstance.SearchAsync<TPrimaryObjectType>(s => s
                .Query(queryContainerDescriptor)
                .From(from)
                .Size(size)
                .Version(includeVersion));
            return search.ToResponseCollection();
        }

        public long Update(TPrimaryObjectType item, bool includeVersion = true)
        {
            if (item == null)
                throw new NullReferenceException($"You cannot update a null { typeof(TPrimaryObjectType) } object");

            item.LastEditDate = DateTime.Now;
            IIndexResponse result;
            if (includeVersion)
                result = _clientInstance.Index(item, v => v.Version(item.DataVersion));
            else
                result = _clientInstance.Index(item);

            if (!result.IsValid)
                throw new Exception($"{typeof(TPrimaryObjectType)} failed to update, ID: {item.Id}");
            return includeVersion ? result.Version : 0;
        }

        public bool Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;
            var result = _clientInstance.Delete<TPrimaryObjectType>(id);
            return result.IsValid;
        }

    }

    public static class SearchResponseExtensions
    {
        public static IEnumerable<TPrimaryObjectType> ToResponseCollection<TPrimaryObjectType>(this ISearchResponse<TPrimaryObjectType> search) where TPrimaryObjectType : GenericMetadata
        {
            var results = new List<TPrimaryObjectType>();
            if (search != null && search.Documents != null)
            {
                foreach (Hit<TPrimaryObjectType> hit in search.Hits)
                {
                    var source = hit.Source;
                    source.Id = hit.Id;
                    source.DataVersion = hit.Version ?? -1;
                    results.Add(source);
                }
            }
            return results;
        }
    }
}
