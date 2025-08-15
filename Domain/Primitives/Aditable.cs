namespace Domain.Primitives
{
    public class Aditable<T> : Entity<T>
    {
        public DateTime CreatedAt { get;  set; }
        public string CreatedBy { get;  set; }
        public DateTime? EditedAt { get;  set; }
        public string? EditedBy { get;  set; }
        public bool IsDeleted  { get;  set; }
        public Aditable()
        {
            IsDeleted = false;
        }
        public Aditable(T id)
            : base(id)
        {
            
        }

    }
}




