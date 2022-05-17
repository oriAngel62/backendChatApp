using Domain;
namespace Repository
{
    public class DB
    {
        public List<Contact> listContacts { get; set; }
        public DB()
        {
            listContacts= new List<Contact>() { new Contact() { Id = 1, Last = "abc", LastDate = DateTime.Now, MessageList = null, NickName = "yes", Server = "abc" },
                        new Contact() { Id = 2, Last = "abcd", LastDate = DateTime.Now, MessageList = null, NickName = "yes", Server = "abc" }
                        };

        }

       
    }
}