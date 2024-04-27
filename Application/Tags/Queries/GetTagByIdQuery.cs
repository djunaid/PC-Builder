using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Security;
using Application.Tags.ViewModel;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Queries
{
    public record GetTagByIdQuery : IRequest<TagVM>
    {
        public int Id { get; set; }

    }
    
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagVM>
    {
        private readonly IApplicationDbContext _context;        

        public GetTagByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<TagVM> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var currentTag = await _context.Tag.Where(x=> x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);


            return currentTag.ToVM();
        }
    }
}
