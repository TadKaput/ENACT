using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Enact.Repository.Sql
{
    public class RepositoryContext : DbContext
    {
        private IConfigurationRoot _config;

        public RepositoryContext(IConfigurationRoot config)
        {
            _config = config;
        }

        public DbSet<object> MyDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = $"Server={_config["Ef:Server"]};Database={_config["Ef:Database"]};Trusted_Connection=true;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
