using Domain.Model;
using Escola.Data.Repositories;

namespace Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(Context context) : base(context)
        {
        }
    }
}
