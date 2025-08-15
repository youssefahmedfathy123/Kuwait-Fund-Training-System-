using Domain.Primitives;

namespace Domain.Entities
{
    public class Company : Aditable<Guid>
    {
        private Company() { }

        public string Name { get;private set; }
        public string About { get; private set; }
        public string? Phone1 { get; private set; }
        public string? Phone2 { get; private set; }
        public string Country { get; private set; }
        public string Manager { get; private set; }
        public AbroadOrInside AbroadOrInside { get; set; }

        public Company(
            string name,
            string about,
            string? phone1,
            string? phone2,
            string country,
            string manager
            )
        {
            Name = name; About = about; Phone1 = phone1; Phone2 = phone2; Country = country; Manager = manager;    
        }


    }
}
public enum AbroadOrInside
{
    Abroad,InSide
}
