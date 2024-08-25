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

        private List<Tag> _tags = new();

        public IReadOnlyCollection<Tag> Tags => _tags;

        public List<PCComponentTag> PCComponentTags { get; set; } = new();

        private List<PriceComponent> _priceComponents = new();
        public IReadOnlyCollection<PriceComponent> PriceComponent => _priceComponents;

        public PCComponent()
        {

        }

        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void AddPriceComponent(PriceComponent priceComponent)
        {
            _priceComponents.Add(priceComponent);
        }

        public void AddTags(List<Tag> tags)
        {
            _tags.AddRange(tags);
        }
    }
}
