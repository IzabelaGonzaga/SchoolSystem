using Domain.Entities;

namespace Domain.Model
{
    public class Register : IEntity
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public EStatus Status { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}