using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class User
    {
        public List<Contact> listContacts { get; set; }

        public User()
        {
            listContacts = new List<Contact>() { new Contact() { Id = 1, Last = "abc", LastDate = DateTime.Now, MessageList = null, NickName = "yes", Server = "abc" },
                        new Contact() { Id = 2, Last = "abcd", LastDate = DateTime.Now, MessageList = null, NickName = "yes", Server = "abc" }
                        };
        }
    }
}
