using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Entities
{
    public class Tag : BaseAuditableEntity
    {
        public string Name { get; set; }
        
        public string Value { get; set; }

        public List<PCComponent> Components { get; set; }

        public Tag() { }

    }
}
