using Application.Tags.Commands;
using Application.Tags.Queries;
using Application.Tags.ViewModel;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Web.Controllers
{
    public class TagController : Controller
    {

        private readonly IMediator _mediatr;

        public TagController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        // GET: SetupController
        public async Task<ActionResult> Index()
        {
            var vm = await _mediatr.Send(new GetAllTagsQuery());
            return View(vm);
        }

        [ActionName("TagList")]
        public async Task<ActionResult> TagList()
        {
            var vm = await _mediatr.Send(new GetAllTagsQuery());
            return View(vm);
        }

        // GET: SetupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Edit(int? Id)
        {
            if(Id is null)
            {
                return BadRequest();
            }

            var vm = await _mediatr.Send(new GetTagByIdQuery() { Id = Id.GetValueOrDefault() });
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TagVM tagvm)
        {
            if(tagvm is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(tagvm);
            }

            var result = await _mediatr.Send(new UpdateTagCommand() { Id = tagvm.Id 
                            , Name = tagvm.Name , TimeStamp = tagvm.SystemTimeStamp , UpdatedBy = "admin" , UpdatedDate = DateTime.Now, Value = tagvm.Value});

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            tagvm.OperationResult = result;

            return View(tagvm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public async Task<ActionResult> Create(TagVM tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            try
            {

                var result = await _mediatr.Send(new CreateTagCommand() { Name = tag.Name, Value = tag.Value, CreatedBy = "admin", CreatedDate = DateTime.Now });

                return Redirect("TagList");
            } 
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(tag);
            }
        }  
        

        [HttpPost]
        public async Task<IResult> Delete(int id)
        {
            return Results.Ok();
        }
       
        
    }
}
