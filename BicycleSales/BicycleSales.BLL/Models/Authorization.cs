using BicycleSales.Constants;

namespace BicycleSales.BLL.Models;

public class Authorization
{
    public int Id { get; set; }

    public string? Login { get; set; }
    public string? Password { get; set; }
    public UserStatus? Status { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Authorization auth &&
               Id == auth.Id &&
               Login == auth.Login &&
               Password == auth.Password &&
               Status == auth.Status;
    }
}