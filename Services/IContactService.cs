using Repository;
using Domain;
namespace Services
{
    public interface IContactService
    {
        public Contact GetContact(int id);
        public List<Contact> GetContacts();

        //POST = ADD CONTACT ?
    }
}