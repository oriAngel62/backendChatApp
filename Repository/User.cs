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
        public int id { get; set; }

    public User(int id)
        {
            this.id = id;
            listContacts = new List<Contact>() { new Contact() { Id = 1, Last = "abc", LastDate = DateTime.Now, MessageList = {new Message()
            {Content = "hi",Type = Domain.Type.text,Id =1,Created = DateTime.Now,Sent=true } ,new Message() {Content = "hi 2 u 2",
                Type = Domain.Type.text,Id =2,Created = DateTime.Now,Sent=false }}, NickName = "yes", Server = "abc" },
                        new Contact() { Id = 2, Last = "abcd", LastDate = DateTime.Now, MessageList = {new Message()
            {Content = "hi",Type = Domain.Type.text,Id =1,Created = DateTime.Now,Sent=true } ,new Message() {Content = "hi 2 u 2",
                Type = Domain.Type.text,Id =2,Created = DateTime.Now,Sent=false }}, NickName = "yes", Server = "abc" }
                        };
        }
    }
}
