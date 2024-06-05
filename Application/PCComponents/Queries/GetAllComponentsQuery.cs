using Application.Common.Mappings;
using Application.Common.Models.Interface;
using Application.PCComponents.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.PCComponents.Queries
{
    public struct GetAllComponentsQuery : IRequest<IEnumerable<PCComponentVM>>;

    public class GetAllComponentsHandler : IRequestHandler<GetAllComponentsQuery, IEnumerable<PCComponentVM>>
    {
        private readonly IPCComponentRepository _pcComponentRepository;
        public GetAllComponentsHandler(IPCComponentRepository pcComponentRepository)
        {
            _pcComponentRepository = pcComponentRepository;
        }

        public async Task<IEnumerable<PCComponentVM>> Handle(GetAllComponentsQuery request, CancellationToken cancellationToken)
        {
            var components = await _pcComponentRepository.GetAllComponentsAsync();

            var componentsVM = components.Select(x => x.ToVM()).ToList();

            return componentsVM;
        }
    }
    
}
