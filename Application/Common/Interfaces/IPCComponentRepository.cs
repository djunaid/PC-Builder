using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPCComponentRepository
    {
        Task<List<PCComponent>> GetAllComponentsAsync();

        Task<PCComponent> GetComponentByIdAsync(int id);

        Task<PCComponent> GetComponentByNameAsync(string name);

        Task<int> CreateComponentAsync(PCComponent component, CancellationToken cancellationToken);

        Task DeleteComponentAsync(int id, CancellationToken cancellationToken);

        Task UpdateComponentAsync(PCComponent component, CancellationToken cancellationToken);
    }
}
