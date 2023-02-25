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
    public async Task<bool> GetUserByEmail(string mail)
    {
        var result = await _context.Users.AnyAsync(u => u.PersonalDetails.Email == mail);
        if (result)
            return true;

        else
            return false;
    }


}
