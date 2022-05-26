using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ContactService : IItemService
    {
        private readonly PomeloDB _context;

        public ContactService(PomeloDB _context1)
        {
            _context = _context1;

        }

        public async Task<Contact> GetContact(string userId, string id)
        {
            return await _context.Contact.FirstOrDefaultAsync(item => (item.Id == id) && item.UserName == userId);
        }
        public async Task<List<Contact>> GetContacts(string user)
        {

            //List<Contact> c= await _context.Contact.Where(item => item.User.UserName == user).ToListAsync();
            //if (c == null)
            //{
            //    return null;
            //}
             List < Contact > c = await _context.Contact.Where(item => item.UserName == user).ToListAsync();
            return c;
        }

        public async Task<List<Message>> GetMessages(string user, string contact)
        {

            return await _context.Message.Where(item => (item.From == user) && (item.To == contact)).ToListAsync();
        }

        public async Task<Message> GetMessage(int id)
        {

            return await _context.Message.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task AddContact(Contact contact)
        {
            //using (var db = new PomeloDB())
            //{
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();
            //}
            //db.Contact.Add(contact);
            //db.SaveChanges();
        }
        public async void UpdateContact(Contact contact)
        {
            _context.Contact.Update(contact);
            await _context.SaveChangesAsync();

        }

        public async void DeleteContact(string userId,string contactId)
        {
            //async Contact c = GetContact(id);
            List<Contact> x = await _context.Contact.Where(item => (item.UserName == userId) && (item.Id == contactId)).ToListAsync();
            _context.Contact.Remove(x[0]);
            await _context.SaveChangesAsync();
        }

        public async void AddMessage(Message message)
        {

            _context.Message.Add(message);
            await _context.SaveChangesAsync();
            //db.Contact.Add(contact);
            //db.SaveChanges();
        }

        public async void UpdateMessage(Message message)
        {
            //maby need to find dirst the key
            _context.Message.Update(message);
            await _context.SaveChangesAsync();
            //db.Contact.Add(contact);
            //db.SaveChanges();
        }

        public async void DeleteMessage(int idMessage)
        {
            //async Contact c = GetContact(id);
            Message x = await _context.Message.FindAsync(idMessage);
            _context.Message.Remove(x);
            await _context.SaveChangesAsync();
        }

    }
    //public void DeleteContact(Contact contact)
    //{
    //    using (var db = new PomeloDB())
    //    {
    //        db.Contact.Remove(contact);
    //        db.SaveChanges();
    //    }
    //}

}





