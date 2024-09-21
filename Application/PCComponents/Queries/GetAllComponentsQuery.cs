using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.PCComponents.ViewModel;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.PCComponents.Queries
{
    public struct GetAllComponentsQuery : IRequest<Result<List<PCComponentVM>>>;

    public class GetAllComponentsHandler : IRequestHandler<GetAllComponentsQuery, Result<List<PCComponentVM>>>
    {
        private readonly IPCComponentRepository _pcComponentRepository;
        public GetAllComponentsHandler(IPCComponentRepository pcComponentRepository)
        {
            _pcComponentRepository = pcComponentRepository;
        }

        public async Task<Result<List<PCComponentVM>>> Handle(GetAllComponentsQuery request, CancellationToken cancellationToken)
        {
            var components = await _pcComponentRepository.GetAllComponentsAsync();

            var componentsVM = components.Select(x => x.ToVM()).ToList();

            

            return componentsVM;
        }
    }
    
}
