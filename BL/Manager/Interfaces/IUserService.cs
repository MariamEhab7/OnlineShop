using DAL;

namespace BL;

public interface IUserService
{
    Task<User> UserRegister(UserLoginDTO model);
    Task<bool> UserLogin(UserLoginDTO model);
    Task<PersonalDetails> AddUserDetails(UserRegisterDTO model);
}
