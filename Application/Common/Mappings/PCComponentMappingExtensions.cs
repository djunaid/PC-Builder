using Application.PCComponents.ViewModel;
using PCBuilder.Domain.Entities;

namespace Application.Common.Mappings
{
    public static class PCComponentMappingExtensions
    {
        public static PCComponentVM ToVM(this PCComponent origin)
        {
            return new PCComponentVM()
            {
                Id = origin.Id,
                Name = origin.Name,
                PriceComponent = origin.PriceComponent,
                Tags = origin.Tags.ToVMList(),
                Rating = origin.Rating,
                Type = origin.Type
            };
        }

        public static List<PCComponentVM> ToVMList(this IEnumerable<PCComponent> origin)
        {
            return origin.Select(x=> x.ToVM()).ToList();
        }
    }
}
