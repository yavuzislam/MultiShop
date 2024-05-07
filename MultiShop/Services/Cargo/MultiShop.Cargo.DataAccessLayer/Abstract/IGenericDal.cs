namespace MultiShop.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    List<T> GetAll();
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
}
