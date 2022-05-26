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
            return await _context.Contact.FirstOrDefaultAsync(item => (item.Id == id) && item.User.UserName== userId);
        }
        public async Task<List<Contact>> GetContacts(string user)
        {

            return await _context.Contact.Where(item => item.User.UserName == user).ToListAsync();

        }

        public async Task<List<Message>> GetMessages(string user, string contact)
        {

            return await _context.Message.Where(item => (item.From.UserName == user) && (item.To.UserName == contact)).ToListAsync();
        }

        public async Task<Message> GetMessage(int id)
        {

            return await _context.Message.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async void AddContact(Contact contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
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
            var x = (Contact)_context.Contact.Where(item => item.User.UserName == userId && item.Id == contactId);
            _context.Contact.Remove(x);
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
            var x =(Message)_context.Message.Where(item =>  item.Id == idMessage);
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





