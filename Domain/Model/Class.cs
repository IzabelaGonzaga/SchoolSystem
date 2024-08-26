namespace Domain.Model
{
    public class Class
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public List<Register> Registers { get; set; }
    }
}
