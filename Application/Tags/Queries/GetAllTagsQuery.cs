using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Tags.ViewModel;
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
        private readonly IApplicationDbContext _context;
        public GetAllTagsHandler(IApplicationDbContext context ) {
            _context = context;
        }
        public async Task<List<TagVM>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tag.ToListAsync(cancellationToken);

            return tags.ToVMList();
        }
    }
}
