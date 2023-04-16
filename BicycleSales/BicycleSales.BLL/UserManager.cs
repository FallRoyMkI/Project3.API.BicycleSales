using BicycleSales.BLL.Interfaces;
using BicycleSales.DAL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;


namespace BicycleSales.BLL;

public class UserManager : IUserManager
{
    private readonly IMapperBLL _mapper;
    private readonly IUserRepository _userRepository;

    public UserManager(IMapperBLL mapper = null, IUserRepository userRepository = null)
    {
        _mapper = mapper ?? new MapperBLL();
        _userRepository = userRepository ?? new UserRepository();
    }

    public Authorization CreateAnAccount(Authorization auth)
    {
        if (_userRepository.IsLoginExist(auth.Login!)) throw new Exception("Login already exist");
        
        var dto = _mapper.MapAuthorizationToAuthorizationDto(auth);
        var callback = _userRepository.CreateAnAccount(dto);
        var result = _mapper.MapAuthorizationDtoToAuthorization(callback);

        return result;
    }
    public Authorization UpdateAccountInfo(Authorization auth)
    {
        if (_userRepository.IsLoginExist(auth.Login!)) throw new Exception("Login already exist");

        var dto = _mapper.MapAuthorizationToAuthorizationDto(auth);
        var callback = _userRepository.UpdateAccountInfo(dto);
        var result = _mapper.MapAuthorizationDtoToAuthorization(callback);

        return result;
    }

    public User AddUserInfo(User user)
    {
        var dto = _mapper.MapUserToUserDto(user);
        var callback = _userRepository.AddUserInfo(dto);
        var result = _mapper.MapUserDtoToUser(callback);

        return result;
    }
    public User UpdateUserInfo(User user)
    {
        var dto = _mapper.MapUserToUserDto(user);
        var callback = _userRepository.UpdateUserInfo(dto);
        var result = _mapper.MapUserDtoToUser(callback);

        return result;
    }
    public User GetUserById(int id)
    {
        var callback = _userRepository.GetUserById(id);
        var result = _mapper.MapUserDtoToUser(callback);

        return result;
    }
}