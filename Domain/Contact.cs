using System;

namespace Domain
{
    public class Contact
    {
        //user name
        public string Id { get; set; }
        //nickname
        public string NickName { get; set; }
        public string Server { get; set; }

        //last message
        //can be null
        public string Last { get; set; }
        //can be null

        public DateTime LastDate { get; set; }

        public List<Message> MessageList { get; set; }




    }
}
