using AutoMapper;
using BL.Manager.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BL;

public class UserService : IUserService
{
    #region Dependancy Injection
    private readonly IUserRepo _userRepo;
    private readonly IPersonalRepo _personalRepo;
    private readonly IAddressRepo _addressRepo;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IGenerateJWT _generateJWT;

    public UserService(IUserRepo userRepo, IPersonalRepo personalRepo, IAddressRepo addressRepo,
        IMapper mapper, IPasswordHasher passwordHasher, IGenerateJWT generateJWT)
    {
        _userRepo = userRepo;
        _personalRepo = personalRepo;
        _addressRepo = addressRepo;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _generateJWT = generateJWT;
    }
    #endregion
    public async Task<User> UserRegister(UserLoginDTO model)
    {
        var result = await _userRepo.GetUserByName(model.UserName);
        if (result != null)
            return null;

        var user = _mapper.Map<User>(model);

        user.UserId = Guid.NewGuid();
        user.Role = "user";
        user.Password = _passwordHasher.PasswordHashing(model.Password);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(ClaimTypes.Role, user.Role),
        };

        user.Token = _generateJWT.JwtGenerator(claims);

        _userRepo.Add(user);
        _userRepo.SaveChanges();

        return user;
    }
    public async Task<bool> UserLogin(UserLoginDTO model)
    {
        var user = await _userRepo.GetUserByName(model.UserName);

        var hashPassword = _passwordHasher.PasswordHashing(model.Password);
        if (hashPassword != user.Password)
            return false;

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(ClaimTypes.Role, user.Role),
        };

        user.Token = _generateJWT.JwtGenerator(claims);

        _userRepo.Update(user);
        _userRepo.SaveChanges();

        return true;
    }
    
    public async Task<PersonalDetails> AddUserDetails(UserRegisterDTO model) // Working but error in swagger
    {
        var DbUser = _mapper.Map<PersonalDetails>(model);
        DbUser.Id = Guid.NewGuid();

        var address = DbUser.Address;
        var assignAdd = _addressRepo.GetById(address.AddressId);
        DbUser.Address = assignAdd;

        var aUser = await _userRepo.GetUserByName(model.User.UserName);
        DbUser.User = aUser;

        _personalRepo.Add(DbUser);
        _personalRepo.SaveChanges();

        var result = _mapper.Map<PersonalDetails>(DbUser);
        return result;
    }

}
