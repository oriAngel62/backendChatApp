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
        public Type Type { get; set; }
        
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public bool Sent { get; set; }

    }
}
