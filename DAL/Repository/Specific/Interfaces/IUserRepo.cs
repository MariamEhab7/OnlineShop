namespace DAL;

public interface IUserRepo : IGenericRepo<User>
{
    Task<bool> GetUserByEmail(string mail);
    Task<User> GetUserByName(string name);
}
