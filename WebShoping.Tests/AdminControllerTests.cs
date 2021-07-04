using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShoping.Controllers;
using WebShoping.Models;
using Xunit;

namespace WebShoping.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void AddUsers()
        {
            var mock = new Mock<UnitTestsModel>();
            mock.Setup(model => model.GetAll()).Returns(GetTestUsers());
        }
        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, Email="Tom", Password="35"},
                new User { Id=2, Email="Alice", Password="29"},
                new User { Id=3, Email="Sam", Password="32"},
                new User { Id=4, Email="Kate", Password="1"}
            };
            return users;
        }
    }
}
