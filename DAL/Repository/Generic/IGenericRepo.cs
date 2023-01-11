namespace DAL;

public interface IGenericRepo<Entity> where Entity : class
{
    List<Entity> GetAll();
    Entity GetById(int id);
    void Add(Entity entity);
    void Update(Entity entity);
    void DeleteById(int id);
    void SaveChanges();
}
