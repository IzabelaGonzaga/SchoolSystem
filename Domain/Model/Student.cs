using Domain.Entities;
using Escola.Data.Entities;

namespace Domain.Model
{
    public class Student : IPerson, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public EUserStatus Status { get; set; }
        public List<Register>? Registers { get; set; }

        public Student(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
            Status = EUserStatus.Active;
            Registers = [];
        }
    }
}