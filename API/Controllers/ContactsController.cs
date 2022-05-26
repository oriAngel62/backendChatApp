using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Services;
using API.Data;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        //{
        private readonly PomeloDB _context;
        private IItemService contactService;
        private string userLogIn = "string";
        public ContactsController(PomeloDB context)
        {
            _context = context;
            contactService = new ContactService(context);
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (_context.Contact != null)
            {
                //var json = Newtonsoft.Json.JsonConvert.SerializeObject(contactService.GetContacts(userLogIn));
                //return Json(await _context.Contact.Where(item => item.UserName == userLogIn).ToListAsync());
                List<Contact> c =await contactService.GetContacts(userLogIn);
                return Json(c);

            }
            return BadRequest();

            //                  View(await _context.Contact.ToListAsync()) :
            //                  Problem("Entity set 'PomeloDB.Contact'  is null.");
            //return Json(contactService.GetContacts(userLogIn));

        }


        // GET: ContactsController/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Details(string id)
        {
            return Json(contactService.GetContact(userLogIn, id));
        }

        [HttpGet("{id}/[action]")]
        public async Task<ActionResult> Messages(string id)
        {
            
            return Json(contactService.GetMessages(userLogIn, id));
        }



        [HttpGet("{id}/messages/{id2}")]
        public async Task<ActionResult> IdMessage(int id2)
        {
            return Json(contactService.GetMessage(id2));
        }


        [HttpPost]
        public async Task<IActionResult> CreateContact([Bind("Id,NickName,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.AddAsync(contact);
                await _context.SaveChangesAsync();

                //contactService.AddContact(contact);
                //return  Ok();
            }
            return  BadRequest();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> EditContact(string id, [Bind("NickName,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactService.UpdateContact(contact);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {

            if (ModelState.IsValid)
            {
                contactService.DeleteContact(userLogIn, id);
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("[action]/{id}/messages")]
        public async Task<ActionResult> GetMeessages(string idContct)
        {
            return Json(contactService.GetMessages(userLogIn, idContct));
        }


        [HttpGet("[action]/{id}/messages/{id2}")]
        public async Task<ActionResult> GetMeessage(string id,int id2)
        {
            return Json(contactService.GetMessage(id2));
        }


        [HttpPost("[action]/{id}/messages")]
        public async Task<IActionResult> CreateMessage(string id,[Bind("Type, Content , Sent, Created")] Message message)
        {
            //add from to (sent) id and login name 
            if (ModelState.IsValid)
            {
                message.From = userLogIn;
                message.To = id;
                //message.Created = DateTime.Now;
                Message m2 = new Message()
                {
                    Type = message.Type,
                    Content = message.Content,
                    Sent = !(message.Sent),
                    Created = message.Created,
                    From = id,
                    To = userLogIn
                };
                contactService.AddMessage(message);
                contactService.AddMessage(m2);
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("[action]/{id}/messages/{id2}")]
        public async Task<IActionResult> EditMessage(int id2,[Bind("Id, Type, Content , Sent")] Message message)
        {
            if (ModelState.IsValid)
            {
                contactService.UpdateMessage(message);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("[action]/{id}/messages/{id2}")]
        public async Task<IActionResult> DeleteMessage(int id2)
        {
            if (ModelState.IsValid)
            {
                contactService.DeleteMessage(id2);
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("[action]/time")]
        public async Task<ActionResult> GetTime()
        {
            return Json(DateTime.Now);
        }

       


        //// GET: Contacts1/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Contacts1/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NickName,Server,Last,LastDate")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        contactService.AddContact(contact);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return await Json(contact);
        //}

        //    // GET: Contacts1/Edit/5
        //    public async Task<IActionResult> Edit(string id)
        //    {
        //        if (id == null || _context.Contact == null)
        //        {
        //            return NotFound();
        //        }

        //        var contact = await _context.Contact.FindAsync(id);
        //        if (contact == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(contact);
        //    }

        //    // POST: Contacts1/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(string id, [Bind("Id,NickName,Server,Last,LastDate")] Contact contact)
        //    {
        //        if (id != contact.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(contact);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ContactExists(contact.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(contact);
        //    }

        //    // GET: Contacts1/Delete/5
        //    public async Task<IActionResult> Delete(string id)
        //    {
        //        if (id == null || _context.Contact == null)
        //        {
        //            return NotFound();
        //        }

        //        var contact = await _context.Contact
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (contact == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(contact);
        //    }

        //    // POST: Contacts1/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(string id)
        //    {
        //        if (_context.Contact == null)
        //        {
        //            return Problem("Entity set 'PomeloDB.Contact'  is null.");
        //        }
        //        var contact = await _context.Contact.FindAsync(id);
        //        if (contact != null)
        //        {
        //            _context.Contact.Remove(contact);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        private bool ContactExists(string id)
        {
            return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }






}

