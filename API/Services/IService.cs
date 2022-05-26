using Domain;
namespace Services
{

    public interface IService
    {
        public Task<Contact> GetContact(string userId, string idContact);
        public  Task<List<Contact>> GetContacts(string user);

        public  Task<List<Message>> GetMessages(string user, string contact);
        public  Task<Message> GetMessage(int id);
        public Task<bool?> AddContact(Contact contact);

        public void UpdateContact(Contact contact);

        public void DeleteContact(string userId, string contactId);

        public void AddMessage(Message message);

        public void UpdateMessage(Message message);
        public void DeleteMessage(int idMessage);


        //POST = ADD CONTACT ?
    }
}