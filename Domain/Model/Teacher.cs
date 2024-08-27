using Domain.Entities;
using Escola.Data.Entities;

namespace Domain.Model
{
    public class Teacher : IPerson, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}