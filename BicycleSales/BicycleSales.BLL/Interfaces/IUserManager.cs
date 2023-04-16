using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IUserManager
{
    public Authorization CreateAnAccount(Authorization auth);
    public Authorization UpdateAccountInfo(Authorization auth);

    public User AddUserInfo(User user);
    public User UpdateUserInfo(User user);

    public User GetUserById(int id);
}