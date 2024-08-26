using Domain.Entities;
using Escola.Data.Entities;

namespace Domain.Model
{
    public class Student: IPerson, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public EStatus? Status { get; set; }
        public List<Register>? Registers { get; set; }
    }
}
