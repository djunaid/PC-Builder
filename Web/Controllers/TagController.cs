using Application.Tags.Commands;
using Application.Tags.Queries;
using Application.Tags.ViewModel;
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
        public ActionResult Index()
        {
            return View();
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

        public async Task<ActionResult> Tag(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var vm = await _mediatr.Send(new GetTagByIdQuery() { Id = Id.GetValueOrDefault() });
            return View("Index",vm);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTag([FromForm] TagVM tag)
        {
            var result =  await _mediatr.Send(new CreateTagCommand() { Name = tag.Name, Value = tag.Value, CreatedBy = "admin", CreatedDate = DateTime.Now});
            
            return Redirect("TagList");            
        }        

        [HttpPost]
        public async Task<IResult> Delete(int id)
        {
            return Results.Ok();
        }
       
        
    }
}
