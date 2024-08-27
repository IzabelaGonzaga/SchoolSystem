using Domain.Model;
using Escola.Data.Repositories;

namespace Data.Repositories;

public class ClassRepository : BaseRepository<Class>, IClassRepository
{
    public ClassRepository(Context context) : base(context)
    {
    }
}