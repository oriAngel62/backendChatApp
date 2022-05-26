using Domain;
namespace Services
{

    public interface IItemService
    {
        public Task<Contact> GetContact(string idContact);
        public  Task<List<Contact>> GetContacts(string user);

        public  Task<List<Message>> GetMessages(string user, string contact);
        public  Task<Message> GetMessage(int id);
        public void AddContact(Contact contact);

        public void UpdateContact(Contact contact);

        public void DeleteContact(string userId, string contactId);


        //POST = ADD CONTACT ?
    }
}