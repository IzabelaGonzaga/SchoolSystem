namespace Data.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        List<T> GetAll();

        void Delete(int id);
    }
}