using Domain.Entities;
using Escola.Data.Repositories;

namespace Data.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class, IEntity
    {
        protected readonly Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
