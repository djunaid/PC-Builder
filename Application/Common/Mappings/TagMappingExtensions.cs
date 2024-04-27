using Application.Tags.ViewModel;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public static class TagMappingExtensions
    {
        public static TagVM ToVM(this Tag origin)
        {
            return new TagVM()
            {
                Id = origin.Id,
                Name = origin.Name,
                Created = origin.Created,
                CreatedBy = origin.CreatedBy,
                LastModified = origin.LastModified,
                LastModifiedBy = origin.LastModifiedBy,
                SystemTimeStamp = origin.SystemTimeStamp,
                Value = origin.Value

            };
        }

        public static List<TagVM> ToVMList(this List<Tag> origin) {  
            
           return origin.Select(x => x.ToVM()).ToList(); ;
        
        }
    }
}
