using Domain.Model;
using Escola.Data.Repositories;

namespace Data.Repositories
{
    public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(Context context) : base(context)
        {
        }
    }
}
