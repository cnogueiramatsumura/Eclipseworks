namespace DataAcess.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);
        List<T> GetAll();
        T GetById(int id);
        void Delete(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
