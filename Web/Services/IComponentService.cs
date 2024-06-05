using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Services
{
    public interface IComponentService
    {
        Task<List<SelectListItem>> GetAllTagsForSelect();
    }
}