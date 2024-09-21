using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    internal class PCComponentRepository : IPCComponentRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public PCComponentRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateComponentAsync(PCComponent component, CancellationToken cancellationToken)
        {
            try
            {

              //  var tags = await _dbContext.Tag.Where(x=> tagsIds.Any(tag => tag == x.Id)).AsNoTracking().ToListAsync();

              //  component.AddPriceComponent(priceComponent);            

                var result = await _dbContext.PCComponent.AddAsync(component);
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                var pcComponentId = result.Entity.Id;
                
                              

                return pcComponentId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteComponentAsync(int id,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PCComponent>> GetAllComponentsAsync()
        {
            var components = await _dbContext.PCComponent.Include(x=> x.PriceComponent).AsNoTracking().ToListAsync();

            return components;
        }

        public Task<PCComponent> GetComponentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PCComponent> GetComponentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateComponentAsync(PCComponent component, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
