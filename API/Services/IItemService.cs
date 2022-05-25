using Domain;
namespace Services
{

    public interface IItemService
    {
        public Task<Contact> GetContact(string idContact);
        public  Task<List<Contact>> GetContacts();

        //public Message GetMessage(string idContact, int idMessage);
        //public List<Message> GetMessages(string idContact);

        //public void AddContact(Contact contact);

        //POST = ADD CONTACT ?
    }
}