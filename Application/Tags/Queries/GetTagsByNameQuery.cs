using Application.Common.Mappings;
using Application.Tags.ViewModel;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Queries
{
    public record GetTagsByNameQuery : IRequest<List<TagVM>>
    {
        public string Query {  get; set; }
    }

    public class GetTagsByNameQueryHandler : IRequestHandler<GetTagsByNameQuery, List<TagVM>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagsByNameQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagVM>> Handle(GetTagsByNameQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.GetAllTagsByNameAsync(request.Query, cancellationToken);

            return tags.Select(x=> x.ToVM()).ToList();
        }

       
    }

}
