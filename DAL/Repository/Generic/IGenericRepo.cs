namespace DAL;

public interface IGenericRepo<Entity> where Entity : class
{
    List<Entity> GetAll();
    Entity GetById(Guid id);
    void Add(Entity entity);
    void Update(Entity entity);
    void DeleteById(Guid id);
    void SaveChanges();
}
