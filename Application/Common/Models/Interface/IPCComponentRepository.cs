using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.Interface
{
    public interface IPCComponentRepository
    {
        Task<IEnumerable<PCComponent>> GetAllComponentsAsync();

        Task<PCComponent> GetComponentByIdAsync (int id);

        Task<PCComponent> GetComponentByNameAsync (string name);

        Task<int> CreateComponentAsync(PCComponent component, int[] tagIds, PriceComponent priceComponent, CancellationToken cancellationToken);

        Task DeleteComponentAsync (int id, CancellationToken cancellationToken);

        Task UpdateComponentAsync (PCComponent component, CancellationToken cancellationToken);
    }
}
