using Themepark.Domain.Contracts;
using Themepark.Domain.Entity;

namespace Themepark.API.Mutations.AddRollercoaster
{
    [ExtendObjectType(name: "Mutation")]
    public class AddRollercoasterMutation
    {
        public async Task<IEnumerable<Rollercoaster>> AddRollercoaster(
            [Service] IRollercoasterRepository rollercoasterRepository,
            AddRollercoasterInput input,
             CancellationToken cancellationToken
            )
        {

            Rollercoaster coaster = new Rollercoaster()
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Type = input.Type
            };

            await rollercoasterRepository.CreateRollercoasterAsync(coaster, cancellationToken);
            return await rollercoasterRepository.GetRollercoastersAsync(cancellationToken);
        }
    }
}
