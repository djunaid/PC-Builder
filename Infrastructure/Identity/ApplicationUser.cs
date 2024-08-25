using Microsoft.AspNetCore.Identity;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        private List<PCComponent> components = new();

        public IReadOnlyCollection<PCComponent> Components { get {  return components; } }

        private List<Tag> tags = new();

        public IReadOnlyCollection<Tag> Tags { get { return tags; } }

        private List<PriceComponent> priceComponents = new();

        public IReadOnlyCollection<PriceComponent> PriceComponents { get { return priceComponents; } }
    }
}
