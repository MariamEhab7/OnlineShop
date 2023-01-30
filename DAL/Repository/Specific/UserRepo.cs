using Microsoft.EntityFrameworkCore;

namespace DAL;

public class UserRepo : GenericRepo<User> , IUserRepo
{
    private readonly ShopContext _context;

    public UserRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetUserByName(string name)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == name.ToLower());
        return result;
    }
}
