using HotChocolate.Data.Sorting;
using Themepark.Domain.Entity;

namespace Themepark.API.Types
{
    public class RollercoasterSortType : SortInputType<Rollercoaster>
    {
        protected override void Configure(ISortInputTypeDescriptor<Rollercoaster> descriptor)
        {
            // For this expiriment don't allow sorting on imageUrls 
            descriptor.Field(x => x.ImageUrl).Ignore();
        }
    }
}
