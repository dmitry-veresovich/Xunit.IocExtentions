using System.Linq;
using ProjectToTest.Entities;
using ProjectToTest.Repositories;

namespace ProjectToTest.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public User GetLastUser()
        {
            return _usersRepository
                .GetUsers()
                .OrderBy(user => user.RegistrationDate)
                .Last();
        }

        public void AddUser(User user)
        {
            _usersRepository.AddUser(user);
        }
    }
}