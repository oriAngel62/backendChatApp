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

        public async Task<Contact> GetContact(string id)
        {
            return await _context.Contact.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Contact>> GetContacts()
        {

            return await _context.Contact.ToListAsync();

        }

        public List<Message> GetMessages(string idContact)
        {
            for (int i=0; i < d.userList[0].listContacts.Count; i++)
            {
                if (d.userList[0].listContacts[i].Id == idContact)
                {
                    return d.userList[0].listContacts[i].MessageList;
                }
            }
            return null;
        }
        public Message GetMessage(string idContact,int idMessage)
        {
            for (int i = 0; i < d.userList[0].listContacts.Count; i++)
            {
                if (d.userList[0].listContacts[i].Id == idContact)
                {
                    return d.userList[0].listContacts[i].MessageList.Where(x => x.Id == idMessage).FirstOrDefault();
                }
            }
            return null;
        }

        public void AddContact(Contact contact)
        {
            d.userList[0].listContacts.Add(contact);
        }


    }

    }

