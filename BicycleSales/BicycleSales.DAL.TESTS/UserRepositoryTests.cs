using BicycleSales.DAL.TESTS.TestCaseSources;

namespace BicycleSales.DAL.TESTS
{
    public class Tests
    {
        private readonly UserRepository _repository = new();

        [SetUp]
        public void SetUp()
        {
            var firstUserAuth = new AuthorizationDto()
            {
                Id = 1,
                Login = "MainTestLogin",
                Password = "MainTestPassword",
                UserStatus = UserStatus.CommonUser
            };
            _repository.CreateAnAccount(firstUserAuth);

            var firstUserInfo = new UserDto()
            {
                Name = "MainTestUserName",
                Email = "MainTestUserEmail",
                Phone = "MainTestUserPhone",
                IsMale = false,
                Authorization = firstUserAuth,
                Shop = new() { Id = 2, Location = "MainTestShopLocation", Name = "VeloDriveShop" }
            };
            _repository.AddUserInfo(firstUserInfo);
        }

        [TestCaseSource(typeof(CreateAnAccountTestSources))]
        public void CreateAnAccountTest(AuthorizationDto input, AuthorizationDto expected)
        {
            var actual = _repository.CreateAnAccount(input);

            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(EditAccountInfoTestSources))]
        public void EditAccountInfoTest(AuthorizationDto input, AuthorizationDto expected)
        {
            var actual = _repository.EditAccountInfo(input);

            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(AddUserInfoTestSources))]
        public void AddUserInfoTest(UserDto input, UserDto expected)
        {
            var actual = _repository.AddUserInfo(input);

            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(EditUserInfoTestSources))]
        public void EditUserInfoTest(UserDto input, UserDto expected)
        {
            var actual = _repository.EditUserInfo(input);

            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(GetUserByIdTestSources))]
        public void GetUserByIdTest(int userId, UserDto expected)
        {
            var actual = _repository.GetUserById(userId);

            Assert.AreEqual(actual, expected);
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}