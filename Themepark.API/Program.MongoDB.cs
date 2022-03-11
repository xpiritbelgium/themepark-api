using System.Security.Authentication;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Themepark.API.Settings;
using Themepark.Domain.Contracts;
using Themepark.Infrastructure.Repositories;

namespace Themepark.API
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoConfig(this IServiceCollection services, IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            var settings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(
              new MongoUrl(settings.ConnectionString)
            );
            mongoSettings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };


            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                return new MongoClient(mongoSettings);
            });

            services.AddSingleton<IRollercoasterRepository, RollercoasterRepository>();
            return services;

        }
    }
}
