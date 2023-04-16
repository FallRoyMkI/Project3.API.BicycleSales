using System.Collections;

namespace BicycleSales.DAL.TESTS.TestCaseSources;

public class CreateAnAccountTestSources : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        var input = new AuthorizationDto()
        {
            Login = "NewUserLogin",
            Password = "NewUserPassword",
            Status = UserStatus.CommonUser
        };
        var expected = new AuthorizationDto()
        {
            Id = 2,
            Login = "NewUserLogin",
            Password = "NewUserPassword",
            Status = UserStatus.CommonUser
        };
        yield return new Object[] { input, expected };
    }
}
public class EditAccountInfoTestSources : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        var input = new AuthorizationDto()
        {
            Id = 1,
            Login = "EditedLogin",
            Password = "EditedPassword",
            Status = UserStatus.CommonUser
        };
        var expected = new AuthorizationDto()
        {
            Id = 1,
            Login = "EditedLogin",
            Password = "EditedPassword",
            Status = UserStatus.CommonUser
        };
        yield return new Object[] { input, expected };
    }
}

public class AddUserInfoTestSources : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        var input = new UserDto()
        {
            Name = "NewUserName",
            Email = "NewUserEmail",
            Phone = "NewUserPhone",
            IsMale = true,
            Authorization = new AuthorizationDto {Id = 2,Login = "NewUserLogin", Password = "NewUserPassword", Status = (UserStatus)1},
            Shop = new ShopDto {Id = 2, Location = "TestShopLocation", Name = "VeloDriveShop"}
        };
    
        var expected = new UserDto()
        {
            Id = 1,
            Name = "NewUserName",
            Email = "NewUserEmail",
            Phone = "NewUserPhone",
            IsMale = true,
            Authorization = new AuthorizationDto { Id = 2, Login = "NewUserLogin", Password = "NewUserPassword", Status = (UserStatus)1 },
            Shop = new ShopDto { Id = 2, Location = "TestShopLocation", Name = "VeloDriveShop" }
        };
        yield return new Object[] { input, expected };
    }
}
public class EditUserInfoTestSources : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        var input = new UserDto()
        {
            Id = 1,
            Name = "EditedUserName",
            Email = "EditedUserEmail",
            Phone = "EditedUserPhone",
            IsMale = true,
            Shop = new ShopDto { Id = 5, Location = "EditedShopLocation", Name = "VeloDriveShop" }
        };

        var expected = new UserDto()
        {
            Id = 1,
            Name = "EditedUserName",
            Email = "EditedUserEmail",
            Phone = "EditedUserPhone",
            IsMale = true,
            Authorization = new AuthorizationDto() { Id = 1, Login = "MainTestLogin", Password = "MainTestPassword", Status = UserStatus.CommonUser },
            Shop = new ShopDto { Id = 5, Location = "EditedShopLocation", Name = "VeloDriveShop" }
        };
        yield return new Object[] { input, expected };
    }
}

public class GetUserByIdTestSources : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        int id = 1;
        var expected = new UserDto()
        {
            Id = 1,
            Name = "MainTestUserName",
            Email = "MainTestUserEmail",
            Phone = "MainTestUserPhone",
            IsMale = false,
            Authorization = new AuthorizationDto() { Id = 1, Login = "MainTestLogin", Password = "MainTestPassword", Status = UserStatus.CommonUser },
            Shop = new() { Id = 2, Location = "MainTestShopLocation", Name = "VeloDriveShop" }
        };
        yield return new Object[] { id, expected };
    }
}