using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Entities
{
    public class PriceComponent  : BaseAuditableEntity
    {
        public decimal Price { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? ExpriyDate { get; set; } = null;

        public int PCComponentId { get; set; }
        public PCComponent PCComponent { get; set; } = null!;

        public PriceComponent()
        {

        }
    }
}
