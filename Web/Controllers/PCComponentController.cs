using Application.PCComponents.ViewModel;
using Application.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PCComponentController : Controller
    {
        private readonly IMediator _mediatr;

        public PCComponentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var tags = await _mediatr.Send(new GetAllTagsQuery());

            var vm = new PCComponentVM();

            vm.Tags = tags;

            

            return View(vm);
        }
    }
}
