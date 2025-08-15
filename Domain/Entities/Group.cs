using Domain.Primitives;

namespace Domain.Entities
{
    public class Group : Aditable<Guid>
    {
        public readonly int MaxMemberInOneGroup = 15;

        public int Member = 0;
        public string Name { get;private set; }
        public Guid BatchId { get;private set; }
        public Batch Batch { get;private set; }
        private Group() { }

        public Group(string name,Guid batchId)
        {
            Name = name;
            BatchId = batchId;
        }

    }
}


