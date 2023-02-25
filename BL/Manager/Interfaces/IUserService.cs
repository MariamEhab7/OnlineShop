using DAL;

namespace BL;

public interface IUserService
{
    Task<User> UserRegister(UserLoginDTO model);
    Task<bool> UserLogin(UserLoginDTO model);
    Task<bool> AddUserDetails(UserInfoDTO model);
}
