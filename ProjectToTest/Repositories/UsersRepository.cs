using System.Collections.Generic;
using ProjectToTest.Entities;

namespace ProjectToTest.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly List<User> _users;

        public UsersRepository()
        {
            _users = new List<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}