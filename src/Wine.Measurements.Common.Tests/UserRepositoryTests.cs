using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Data.InMem;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Tests;

public class UserRepositoryTests
{
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000", "userName", "paswordHash", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", null, "paswordHash", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", null, "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", "paswordHash", null)]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "", "paswordHash", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", "", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", "paswordHash", "")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "   ", "paswordHash", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", "   ", "FullName")]
    [InlineData("11c43ee8-b9d3-4e51-b73f-bd9dda66e29c", "userName", "paswordHash", "   ")]
    public void RegisterUser_InvalidDataShouldFail(string userId, string userName, string passwordHash, string fullName)
    {
        // Arrange
        IUserRepository repository = new InMemUserRepository();
        var user = new User()
        {
            UserId = Guid.Parse(userId),
            UserName = userName,
            PasswordHash = passwordHash,
            FullName = fullName
        };

        // Act
        Assert.Throws<ArgumentException>(() => repository.RegisterUser(user));
    }

    [Fact]
    public void RegisterUser_DuplicatedUserShouldFail()
    {
        // Arrange
        IUserRepository repository = new InMemUserRepository();
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            UserName = "userName",
            PasswordHash = "passwordHash",
            FullName = "fullName"
        };

        // Act
        repository.RegisterUser(user);
        Assert.Throws<ArgumentException>(() => repository.RegisterUser(user));
    }

    [Fact]
    public void RegisterUser_CorrectUserDataShouldWork()
    {
        IUserRepository repository = new InMemUserRepository();
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            UserName = "userName",
            PasswordHash = "passwordHash",
            FullName = "fullName"
        };

        // Act
        repository.RegisterUser(user);
    }

    [Fact]
    public void GetRegisteredUsers_ShouldGetAList()
    {
        // Arrange
        IUserRepository repository = new InMemUserRepository();

        // Act
        var actual = repository.GetRegisteredUsers();

        // Assert
        Assert.NotNull(actual);
    }
}
