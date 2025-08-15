using Domain.Primitives;

namespace Domain.Entities
{
    public class Message : Aditable<Guid>
    {
        private Message() { }

        public Message(string senderId, string receiverId, string content)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            SentAt = DateTime.UtcNow;
        }

        public string SenderId { get; private set; }
        public User Sender { get; private set; }
        public string ReceiverId { get; private set; }
        public User Receiver { get; private set; }
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }
    }

}
