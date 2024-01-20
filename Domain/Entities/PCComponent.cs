using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Entities
{
    public class PCComponent : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        [Column(TypeName="decimal(5,2)")]
        public decimal Rating { get; set; }

        public List<Tag> Tags { get; } = new();

        public ICollection<PriceComponent> PriceComponent { get; } = new List<PriceComponent>();
    }
}
