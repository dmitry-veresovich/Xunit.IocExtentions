using System;
using ProjectToTest.Entities;
using ProjectToTest.Repositories;
using ProjectToTest.Services;
using Xunit;
using Xunit.IocExtentions.Attributes;

namespace ProjectToTest.Tests
{
    public class UsersServiceTests
    {
        [Theory,
            Dependency(typeof(IUsersRepository), typeof(UsersRepository)),
            AutofacData(typeof(UsersService), "some data"),
            //AutofacData(typeof(UsersService), "some incorrect data"),
        ]
        public void UsersServiceShouldReturnTheLastUser(UsersService usersService, string someData)
        {
            var someUser = new User
            {
                Name = "Some user",
                RegistrationDate = new DateTime(2000, 12, 1),
            };
            var lastUser = new User
            {
                Name = "Last user",
                RegistrationDate = DateTime.Today,
            };
            var firstUser = new User
            {
                Name = "First user",
                RegistrationDate = new DateTime(1995, 12, 1),
            };
            usersService.AddUser(someUser);
            usersService.AddUser(lastUser);
            usersService.AddUser(firstUser);

            var result = usersService.GetLastUser();
            Assert.Equal(lastUser, result);
            Assert.Equal("some data", someData);
        }
    }
}