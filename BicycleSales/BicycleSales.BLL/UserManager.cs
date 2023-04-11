using BicycleSales.BLL.Models;
using BicycleSales.DAL;



namespace BicycleSales.BLL;

public class UserManager
{
    private readonly MapperBLL _mapper;

    public UserManager(MapperBLL mapper = null)
    {
        _mapper = mapper ?? new MapperBLL();
    }

    public Authorization CreateAnAccount(Authorization auth)
    {
        var dto = _mapper.MapAuthorizationToAuthorizationDto(auth);
        var callback = new UserRepository().CreateAnAccount(dto);
        var result = _mapper.MapAuthorizationDtoToAuthorization(callback);

        return result;
    }

    public User AddUserInfo(User user)
    {
        var dto = _mapper.MapUserToUserDto(user);
        var callback = new UserRepository().AddUserInfo(dto);
        var result = _mapper.MapUserDtoToUser(callback);

        return result;
    }
}