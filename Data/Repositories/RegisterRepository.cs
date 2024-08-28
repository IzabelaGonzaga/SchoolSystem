using Domain.Model;
using Escola.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(Context context) : base(context)
        {
        }
    }
}