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
    public class Service : IService
    {
        private readonly PomeloDB _context;

        public Service(PomeloDB _context1)
        {
            _context = _context1;

        }

        public async Task<Contact> GetContact(string userId, string id)
        {
            //Contact c = await _context.Contact.FirstOrDefaultAsync(item => (item.Id == id) && item.UserName == userId);
            List<Contact> c = await _context.Contact.Where(item => (item.Id == id) && item.UserName == userId).ToListAsync();
            if (c == null)
            {
                return null;
            }

            return c[0];
        }
        public async Task<List<Contact>> GetContacts(string user)
        {

            //List<Contact> c= await _context.Contact.Where(item => item.User.UserName == user).ToListAsync();
            //if (c == null)
            //{
            //    return null;
            //}


            List< Contact > c = await _context.Contact.Where(item => item.UserName == user).ToListAsync();
            return c;
          
        }

        public async Task<List<Message>> GetMessages(string user, string contact)
        {
            if(_context.Message == null)
            {
                return null;
            }

            List<Message> m = await _context.Message.Where(item => (item.From == user) && (item.To == contact)).ToListAsync();
        
            if (m == null)
            {
                return null;
            }

            return m;
        }

        public async Task<Message> GetMessage(int id)
        {

            return await _context.Message.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<bool?> AddContact(Contact contact)
        {
            if (_context.Contact == null || contact == null)
            {
                return null;
            }
            //using (var db = new PomeloDB())
            //{
            _context.Contact.Add(contact);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return true;
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





