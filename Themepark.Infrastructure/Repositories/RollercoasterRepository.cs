using MongoDB.Bson;
using MongoDB.Driver;
using Themepark.Domain.Contracts;
using Themepark.Domain.Entity;

namespace Themepark.Infrastructure.Repositories
{
    public class RollercoasterRepository : IRollercoasterRepository
    {
        private const string databaseName = "themepark";
        private const string collectionName = "rollercoaster";

        private readonly IMongoCollection<Rollercoaster> _RollercoasterCollection;
        private readonly FilterDefinitionBuilder<Rollercoaster> _filterBuilder = Builders<Rollercoaster>.Filter;

        public RollercoasterRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _RollercoasterCollection = database.GetCollection<Rollercoaster>(collectionName);
        }

        public async Task CreateRollercoasterAsync(Rollercoaster Rollercoaster, CancellationToken cancellationToken)
        {
            await _RollercoasterCollection.InsertOneAsync(Rollercoaster, null, cancellationToken);
        }

        public async Task DeleteRollercoasterAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = _filterBuilder.Eq(coaster => coaster.Id, id);
            await _RollercoasterCollection.DeleteOneAsync(filter, cancellationToken);
        }

        public async Task<Rollercoaster> GetRollercoasterByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = _filterBuilder.Eq(Rollercoaster => Rollercoaster.Id, id);

            var result = await _RollercoasterCollection.FindAsync(filter, null, cancellationToken);
            return result.SingleOrDefault(cancellationToken);
        }

        public async Task<IEnumerable<Rollercoaster>> GetRollercoastersAsync(CancellationToken cancellationToken)
        {
            var results = await _RollercoasterCollection.FindAsync(new BsonDocument(), null, cancellationToken);

            return results.ToList(cancellationToken);
        }

        public async Task UpdateRollercoasterAsync(Rollercoaster Rollercoaster, CancellationToken cancellationToken)
        {
            var filter = _filterBuilder.Eq(existingRollercoaster => existingRollercoaster.Id, Rollercoaster.Id);
            await _RollercoasterCollection.ReplaceOneAsync(filter, Rollercoaster, cancellationToken: cancellationToken);
        }
    }
}
