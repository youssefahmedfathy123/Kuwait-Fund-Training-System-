using Domain.Primitives;

namespace Domain.Entities
{
    public class Feedback : Aditable<Guid>
    {
        private Feedback() { }
        public Feedback(string userId, Guid courceId, string opinion) { 
            UserId = userId;
            CourceId = courceId;
            Opinion = opinion;
        }

        public string UserId { get;private set; }
        public User User { get;private set; }
        public Guid CourceId { get;private set; }
        public Cource Cource { get;private set; }
        public string Opinion { get;private set; }

        

    }
}
