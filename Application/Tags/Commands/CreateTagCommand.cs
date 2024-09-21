using Application.Common.Interfaces;
using Application.Tags.ViewModel;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Commands
{
    public record CreateTagCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        

    }

    public class CreateTagHandler : IRequestHandler<CreateTagCommand, int>
    {

        private readonly ITagRepository _tagRepository;

        public CreateTagHandler(ITagRepository tagRepository)
        {
            
            _tagRepository = tagRepository;
        }
        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Tag tag = new();
                tag.Name = request.Name;
                tag.Value = request.Value;
                tag.CreatedBy = request.CreatedBy;
                tag.LastModifiedBy = request.CreatedBy;
                tag.Created = request.CreatedDate;
                tag.LastModified = request.CreatedDate;


                var newTagId = await _tagRepository.CreateTagAsync(tag, cancellationToken);
                
                return newTagId;


            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
