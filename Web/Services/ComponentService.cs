using Application.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IMediator _mediatR;

        public ComponentService(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<List<SelectListItem>> GetAllTagsForSelect()
        {
            var tags = await _mediatR.Send(new GetAllTagsQuery());

            return tags.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
        }
    }
}
