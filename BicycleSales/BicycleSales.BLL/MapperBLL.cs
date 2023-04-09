using AutoMapper;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL;

public class MapperBLL
{
    private readonly MapperConfiguration _cfg;

    public MapperBLL()
    {
        _cfg = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<AuthorizationDto, Authorization>().ReverseMap();

                cfg.CreateMap<UserDto, User>().ReverseMap();
            });
    }

    public Authorization MapAuthorizationDtoToAuthorization(AuthorizationDto dto)
    {
        return _cfg.CreateMapper().Map<Authorization>(dto);
    }
    public AuthorizationDto MapAuthorizationToAuthorizationDto(Authorization auth)
    {
        return _cfg.CreateMapper().Map<AuthorizationDto>(auth);
    }

    public User MapUserDtoToUser(UserDto dto)
    {
        return _cfg.CreateMapper().Map<User>(dto);
    }
    public UserDto MapUserToUserDto(User user)
    {
        return _cfg.CreateMapper().Map<UserDto>(user);
    }
}