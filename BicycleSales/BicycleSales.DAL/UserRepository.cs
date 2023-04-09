using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL;

public class UserRepository
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
    public AuthorizationDto EditAccountInfo(AuthorizationDto auth)
    {
        var update = _context.Authorizations.ToList().Find(x => x.Id==auth.Id);
        if (update is not null)
        {
            update.Login = auth.Login;
            update.Password = auth.Password;
            update.UserStatus = auth.UserStatus;
        }
        else
        {
            throw new ArgumentException("Cannot find user with such Authorization Id");
        }

        _context.SaveChanges();
        return update;
    }

    public UserDto AddUserInfo(UserDto user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    public UserDto EditUserInfo(UserDto user)
    {
        var update = _context.Users.ToList().Find(x => x.Id == user.Id);
        if (update is not null)
        {
            update.Name = user.Name;
            update.Email = user.Email;
            update.Phone = user.Phone;
            update.IsMale = user.IsMale;
            update.Shop = user.Shop;
        }
        else
        {
            throw new ArgumentException("Cannot find user with such id");
        }

    
        _context.SaveChanges();

        return update;
    }

    public UserDto GetUserById(int userId)
    {
        var result = _context.Users.ToList().Find(x => x.Id == userId);
        if (result is not null)
        {
            return result;
        }
        throw new ArgumentException("Cannot find user with such id");
    }
}