using Application.Common.Models;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.ViewModel
{
    public class TagVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        //public List<PCComponent> PCComponents { get; } = new();
        public string TagFullName 
        {  get   {   return string.Format($"{Name} - {Value}");       } 
        }

        public DateTimeOffset Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public byte[]? SystemTimeStamp { get; set; }

        public Result? OperationResult { get; set; }
    }
}
