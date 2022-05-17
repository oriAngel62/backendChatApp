using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;

namespace Services
{
    public class ContactService : IContactService
    {
        private DB d = new DB();
        public Contact GetContact(int id)
        {
            return d.listContacts.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Contact> GetContacts()
        {

            return d.listContacts;

        }

    }
}
