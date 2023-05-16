using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public readonly IMongoCollection<TEntity> Collection;
    }
}
