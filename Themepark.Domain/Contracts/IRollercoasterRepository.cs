using Themepark.Domain.Entity;

namespace Themepark.Domain.Contracts
{
    public interface IRollercoasterRepository
    {
        Task<Rollercoaster> GetRollercoasterByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Rollercoaster>> GetRollercoastersAsync(CancellationToken cancellationToken);
        Task CreateRollercoasterAsync(Rollercoaster Rollercoaster, CancellationToken cancellationToken);
        Task UpdateRollercoasterAsync(Rollercoaster Rollercoaster, CancellationToken cancellationToken);
        Task DeleteRollercoasterAsync(Guid id, CancellationToken cancellationToken);
    }
}
