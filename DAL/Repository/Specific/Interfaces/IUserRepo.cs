namespace DAL;

public interface IUserRepo : IGenericRepo<User>
{
    Task<User> GetUserByName(string name);
}
