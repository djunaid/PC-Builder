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
        private readonly ITagRepository _tagRepository;

        public GetTagByIdQueryHandler(ITagRepository tagRepository)
        {           
            _tagRepository = tagRepository;
        }

        public async Task<TagVM> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await _tagRepository.GetTagByIdAsync(request.Id, cancellationToken);

                return tag.ToVM();
            } 
            catch (Exception ex)
            {
                return new TagVM();     
            }                        
        }
    }
}
