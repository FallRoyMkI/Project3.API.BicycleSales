using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL;

public class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context = null)
    {
        _context = context ?? new UserContext();
    }

    public AuthorizationDto CreateAnAccount(AuthorizationDto auth)
    {
        _context.Authorizations.Add(auth);
        _context.SaveChanges();
        return auth;
    }
    public AuthorizationDto UpdateAccountInfo(AuthorizationDto auth)
    {
        var update = _context.Authorizations.ToList().Find(x => x.Id == auth.Id);
        if (update is null) throw new ArgumentException("Cannot find user with such Authorization Id");

        if (auth.Login is not null) update.Login = auth.Login;
        if (auth.Password is not null) update.Password = auth.Password;
        if (auth.Status is not null) update.Status = auth.Status;

        _context.SaveChanges();
        return update;
    }

    public UserDto AddUserInfo(UserDto user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    public UserDto UpdateUserInfo(UserDto user)
    {
        var update = _context.Users.ToList().Find(x => x.Id == user.Id);
        if (update is null) throw new ArgumentException("Cannot find user with such Id");

        if (user.Name is not null) update.Name = user.Name;
        if (user.Email is not null) update.Email = user.Email;
        if (user.Phone is not null) update.Phone = user.Phone;
        if (user.IsMale is not null) update.IsMale = user.IsMale;
        if (user.Shop is not null) update.Shop = user.Shop;

        _context.SaveChanges();
        return update;
    }

    public UserDto GetUserById(int id)
    {
        var result = _context.Users.ToList().Find(x => x.Id == id);
        if (result is null) throw new ArgumentException("Cannot find user with such id");

        return result;
    }
    public AuthorizationDto GetAuthorizationById(int id)
    {
        var result = _context.Authorizations.ToList().Find(x => x.Id == id);
        if (result is null) throw new ArgumentException("Cannot find user with such Authorization Id");

        return result;
    }

    public bool IsLoginExist(string login)
    {
        return _context.Authorizations.ToList().Contains(_context.Authorizations.ToList().Find(x => x.Login == login));
    }
}