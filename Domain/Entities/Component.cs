using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Component : BaseAuditableEntity
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public float Rating { get; set; }

        public List<Tag> Tags { get; } = new();

        public ICollection<ComponentPrice> ComponentPrice { get; } = new List<ComponentPrice>();
    }
}
