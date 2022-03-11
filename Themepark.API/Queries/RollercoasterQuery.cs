using Themepark.API.Types;
using Themepark.Domain.Contracts;
using Themepark.Domain.Entity;

namespace Themepark.API.Queries
{
    [ExtendObjectType(name: "Query")]
    public class RollercoasterQuery
    {
        [GraphQLType(typeof(ListType<RollercoasterType>))]
        [UseFiltering(typeof(RollercoasterFilterType))]
        [UseSorting(typeof(RollercoasterSortType))]
        public Task<IEnumerable<Rollercoaster>> GetRollerCoasters([Service] IRollercoasterRepository rollercoasterRepository)
        {
            return rollercoasterRepository.GetRollercoastersAsync(CancellationToken.None);
        }
    }
}
