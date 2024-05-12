using Application.Common.Interfaces;
using Application.Common.Models;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.Commands;

public record UpdateTagCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Value { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTimeOffset? UpdatedDate { get; set; } = DateTimeOffset.Now;

    public byte[] TimeStamp { get; set; }
            
}

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Result>
{
    private readonly IApplicationDbContext _context;
    public UpdateTagHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        List<string>? errors = new List<string>();
        try
        {
            var tag = _context.Tag.FirstOrDefault(x => x.Id == request.Id);

            if (tag is null)
            {
                throw new ArgumentException("Id not found");
            }

            tag.Name = request.Name;
            tag.Value = request.Value;
            tag.LastModifiedBy = request.UpdatedBy;
            tag.LastModified = request.UpdatedDate!.Value;
            tag.SystemTimeStamp = request.TimeStamp;
           
            _context.Tag.Update(tag);

            await _context.SaveChangesAsync(cancellationToken);

            var result = new Result(true, null);

            return result;

        }
        catch(DbUpdateConcurrencyException ex) {
            errors.Add(ex.Message);

            var dbTag = (Tag)ex.Entries.FirstOrDefault().Entity;

            var result = new Result(false, errors);
            return result;
        } catch(ArgumentException ex)
        {
            errors.Add(ex.Message);
            var result = new Result(false, errors);
            return result;
        } catch (DbUpdateException ex)
        {
            errors.Add(ex.Message);
            var result = new Result(false, errors);
            return result;
        }
    }

}


