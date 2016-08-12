using Elasticsearch.Net;
using Nest;
using System;

namespace Enact.Repository.Es
{
    public class RepositoryClient
    {
        public ElasticClient Instance { get; private set; }
        
        public RepositoryClient(string uri, string index)
        {
            var node = new Uri(uri);
            var pool = new SingleNodeConnectionPool(node, null);
            var settings = new ConnectionSettings(pool);
            settings.DefaultIndex(index);
            Instance = new ElasticClient(settings);
        }

        public static bool CreateNewIndex(ElasticClient clientInstance, string index, int? replicas, int? shards)
        {
            IndexState indexState = new IndexState
            {
                Settings = new IndexSettings
                {
                    NumberOfReplicas = replicas ?? 1,
                    NumberOfShards = shards ?? 6
                }
            };
            var response = clientInstance.CreateIndex(index, i => i.InitializeUsing(indexState));
            return response.IsValid;
        }

    }
}
