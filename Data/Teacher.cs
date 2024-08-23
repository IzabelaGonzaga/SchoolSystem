using Escola.Data.Entities;

namespace Escola.Data
{
    public class Teacher : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
