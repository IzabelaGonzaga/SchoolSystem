namespace Data.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);

        void Add(T entidade);

        void Update(T entidade);

        List<T> GetAll();

        void Delete(int id);
    }
}
