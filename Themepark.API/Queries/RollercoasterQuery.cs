using Themepark.API.Types;
using Themepark.Domain.Contracts;
using Themepark.Domain.Entity;

namespace Themepark.API.Queries
{
    [ExtendObjectType(name: "Query")]
    public class RollercoasterQuery
    {
        [GraphQLType(typeof(ListType<RollercoasterType>))]
        public Task<IEnumerable<Rollercoaster>> GetRollerCoasters([Service] IRollercoasterRepository rollercoasterRepository)
        {
            return rollercoasterRepository.GetRollercoastersAsync(CancellationToken.None);

            //var coasters = new List<RollercoasterType>()
            //{
            //    new RollercoasterType("FLY","Flying Coaster","FLY.jpg"),
            //    new RollercoasterType("Nemesis","Flying Coaster","FLY.jpg"),
            //    new RollercoasterType("Furry","Launch coaster","FLY.jpg"),
            //};

            //return coasters;
        }
    }
}
