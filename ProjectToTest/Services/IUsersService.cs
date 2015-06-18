using ProjectToTest.Entities;

namespace ProjectToTest.Services
{
    public interface IUsersService
    {
        User GetLastUser();
        void AddUser(User user);
    }
}