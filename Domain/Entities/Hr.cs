using Domain.Primitives;

namespace Domain.Entities
{
    public class Hr : Aditable<Guid>
    {
        public string Name { get;private set; }
        public string NationalId { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        private Hr()
        {
            
        }
        public Hr(string name,string nationalId,DateTime dateofbirth)
        {
            Name = name;
            NationalId = nationalId;
            DateOfBirth = dateofbirth;
        }

    }
}



