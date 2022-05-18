using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IItemService contactService;
        // GET: ContactsController

        public ContactsController()
        {
            contactService = new ContactService();
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Json(contactService.GetContacts());
        }

        // GET: ContactsController/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Details(string id)
        {
            return Json(contactService.GetContact(id));
        }

        [HttpGet("{id}/[action]")]
        public async Task<ActionResult> Messages(string id)
        {
            return Json(contactService.GetMessages(id));
        }



        [HttpGet("{id}/messages/{id2}")]
        public async Task<ActionResult> IdMessage(string id,int id2)
        {
            return Json(contactService.GetMessage(id,id2));
        }
        [HttpPost]

        public void Create()
        {

        }
    }
}
