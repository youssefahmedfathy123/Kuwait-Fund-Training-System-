using Domain.Primitives;

namespace Domain.Entities
{
    public class PreferedCompanies : Aditable<Guid>
    {
        public string UserId { get;private set; }
        public User User { get;private set; }
        public string CompanyName { get;private set; }
        
        private PreferedCompanies() { }
        public PreferedCompanies(string userId, string companyName)
        {
            UserId = userId;
            CompanyName = companyName;
        }
    }
}



