using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComponentPrice  : BaseAuditableEntity
    {
        public int ComponentID { get; set; }
        public decimal Price { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpriyDate { get; set; }

        public Component Component { get; }
    }
}
