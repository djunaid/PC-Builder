using Application.PCComponents.Commands;
using Application.PCComponents.ViewModel;
using Application.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Web.Controllers
{
    [Authorize]
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

            var vm = new PCComponentWithTags();
            vm.PCComponentVM = new();

            vm.PCComponentVM.Tags = tags;

            

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PCComponentWithTags vm)
        {            
            
            if(vm.SelectedTags is null)
            {
                return View(vm);
            }

            int[] selectedTags = vm.SelectedTags.Split(",").Select(x => int.Parse(x)).ToArray();

            var command = new CreateComponentCommand { Name = vm.PCComponentVM.Name, Price = vm.PCComponentVM.Price, Type = vm.PCComponentVM.Type, Tags = selectedTags , CreatedBy = User.Identity.Name};
            var result = await _mediatr.Send(command);

            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}

public class PCComponentWithTags
{
    public PCComponentVM PCComponentVM { get; set; }

    [Required(ErrorMessage = "Tags are required for the component")]
    public string SelectedTags { get; set; }
}
