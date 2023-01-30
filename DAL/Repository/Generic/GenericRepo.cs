namespace DAL;

public class GenericRepo<Entity> : IGenericRepo<Entity> where Entity : class
{
    private readonly ShopContext _context;

    public GenericRepo(ShopContext context)
    {
        _context = context;
    }
    public void Add(Entity entity)
    {
        _context.Add(entity);
    }
    public List<Entity> GetAll()
    {
        return _context.Set<Entity>().ToList();
    }

    public Entity? GetById(Guid id)
    {
        return _context.Set<Entity>().Find(id);
    }

    public void Update(Entity entity)
    {

    }

    public void DeleteById(Guid id)
    {
        var entity = GetById(id);
        _context.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
