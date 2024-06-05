using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Repositories.Interface;
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

    public byte[] SystemTimeStamp { get; set; }
            
}

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Result>
{

    private readonly ITagRepository _tagRepository;
    public UpdateTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        List<string>? errors = new List<string>();
        var result = new Result(true, new List<string>());
        try
        {
            var tag = await _tagRepository.GetTagByIdAsync(request.Id, cancellationToken);

            if (tag is null)
            {
                result.Succeeded = false;
                errors.Add("Record was deleted by someone.");
                result.Errors = errors!.ToArray();
            }

            

            tag.Name = request.Name;
            tag.Value = request.Value;
            tag.LastModifiedBy = request.UpdatedBy;
            tag.LastModified = request.UpdatedDate!.Value;            
           
            await _tagRepository.UpdateTagAsync(tag, cancellationToken);

            return result;

        }
        catch(DbUpdateConcurrencyException ex) {

            result.Succeeded = false;
            var exceptionTag = ex.Entries.Single();
            var clientTag = (Tag)exceptionTag.Entity;
            var dbTagEntry = exceptionTag.GetDatabaseValues();

            if(dbTagEntry is null)
            {
                
                errors.Add("The record was removed.");
                result.Errors = errors!.ToArray();
                return result;
            }

            var dbTagValue = (Tag)dbTagEntry.ToObject();

            if(dbTagValue.Name != clientTag.Name)
            {
                errors.Add($"Name: Current value = {dbTagValue.Name}");
            }
            if(dbTagValue.Value != clientTag.Value)
            {
                errors.Add($"Value: Current value = {dbTagValue.Value}");
            }

            errors.Add("The record you are trying to update is already updated by other user, /n Please go back to the list and try updating again");

          
            result.Errors = errors!.ToArray();
            return result;
        } catch(ArgumentException ex)
        {
            errors.Add(ex.Message);
            result.Succeeded = false;
            result.Errors = errors!.ToArray();            
            return result;
        } catch (DbUpdateException ex)
        {
            errors.Add(ex.Message);
            result.Succeeded = false;
            result.Errors = errors!.ToArray();
            return result;
        }
    }

}


