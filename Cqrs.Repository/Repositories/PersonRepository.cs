using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contract;
using Cqrs.Domain.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public readonly IMongoCollection<Person> Collection;
        public PersonRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings) : base(client, settings)
        {
            
        }
        //[Obsolete("Obsolete")]
        public async Task InsertAsync(Person person, CancellationToken cancellation)
        {
           
            await Collection.InsertOneAsync(person, cancellationToken: cancellation);
        }
        public async Task<IEnumerable<Person>> GetAsync(Expression<Func<Person,bool>> expression, CancellationToken cancellation)
        {
            var filter = Builders<Person>.Filter.Where(expression);
            return await Collection.Find(filter).ToListAsync(cancellation);
        }

   
    }
}
