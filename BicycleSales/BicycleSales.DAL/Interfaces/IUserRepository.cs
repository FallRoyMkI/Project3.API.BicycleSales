using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IUserRepository
{
    public AuthorizationDto CreateAnAccount(AuthorizationDto auth);
    public AuthorizationDto UpdateAccountInfo(AuthorizationDto auth);

    public UserDto AddUserInfo(UserDto user);
    public UserDto UpdateUserInfo(UserDto user);

    public AuthorizationDto GetAuthorizationById(int id);
    public UserDto GetUserById(int userId);

    public bool IsLoginExist(string login);
    public bool IsUserExist(int id);
}