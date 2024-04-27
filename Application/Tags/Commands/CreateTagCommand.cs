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

        public readonly IApplicationDbContext _context;

        public CreateTagHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Tag tagVM = new();
                tagVM.Name = request.Name;
                tagVM.Value = request.Value;
                tagVM.CreatedBy = request.CreatedBy;
                tagVM.LastModifiedBy = request.CreatedBy;
                tagVM.Created = request.CreatedDate;
                tagVM.LastModified = request.CreatedDate;

                var tag= await _context.Tag.AddAsync(tagVM);
                await _context.SaveChangesAsync(cancellationToken);
                

                return tag.Entity.Id;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
