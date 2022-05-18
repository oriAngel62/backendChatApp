using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IContactService contactService;
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
        public async Task<ActionResult> Details(int id)
        {
            return Json(contactService.GetContact(id));
        }

        [HttpPost]

        public void Create()
        {

        }
    }
}
