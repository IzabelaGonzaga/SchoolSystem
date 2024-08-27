using Domain.Model;
using Escola.Data.Repositories;

namespace Data.Repositories
{
    public class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(Context context) : base(context)
        {
        }
    }
}