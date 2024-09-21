using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Tags.ViewModel;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Queries
{
    public struct GetAllTagsQuery : IRequest<List<TagVM>>;
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, List<TagVM>>
    {
        private readonly ITagRepository _tagRepository;

        public GetAllTagsHandler(ITagRepository tagRepository)
        {
            
            _tagRepository = tagRepository;
        }
        public async Task<List<TagVM>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.GetAllTagsAsync(cancellationToken);

            return tags.ToVMList();
        }
    }
}
