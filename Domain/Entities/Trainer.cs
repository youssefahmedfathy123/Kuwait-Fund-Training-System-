using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Trainer : Aditable<Guid>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid BatchId { get; private set; }
        public Batch Batch { get; private set; }
        public Guid? CompanyId { get;private set; }
        public Company? Company { get; private set; }
        public List<Cource> Cources { get;private set; }
        public User User { get; private set; }
        public string UserId { get; private set; }

        public Trainer(string name, string email,string userId, Guid batchId, Guid? companyId = null)
        {
            Name = name;
            Email = email;
            BatchId = batchId;
            UserId= userId;
            CompanyId = companyId;
        }
    }
}


