using System.Collections.Generic;
using ProjectToTest.Entities;

namespace ProjectToTest.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);
    }
}