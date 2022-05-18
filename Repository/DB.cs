using Domain;
namespace Repository
{
    public class DB
    {
        public List<User> ConnectedUser { get; set; }
        public DB()
        {
            ConnectedUser = new List<User>();
            ConnectedUser.Add();

        }

       
    }
}