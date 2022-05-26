using System;

namespace Domain
{
    public enum Type
    {
        text,
        video,
        image,
        audio
    }
    public class Message
    {
        public int Id { get; set; }
        //from to ?

        public User From { get; set; }

        public User To { get; set; }

        public Type Type { get; set; }
        
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public bool Sent { get; set; }

    }
}
