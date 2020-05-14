using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebApi.Controllers;
using Xunit;

namespace WebApi.xUnitTests
{
    public class UsersControllerTests
    {
        private readonly Mock<ILogger<UsersController>> _mockLogger;
        private readonly IMapper _mockMapper;
        private readonly IUsersRepository _repository;
        private readonly UsersController _usersController;
        private readonly IOptions<AppSettings> _appSettings = Options.Create(new AppSettings() { KeyForEncrypting = "xYnwew3464f", Secret = "acf/Twq4NphhnEaAn3SH6Q==" });

        public UsersControllerTests()
        {
            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger
            _mockLogger = new Mock<ILogger<UsersController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            // Mapper
            _mockMapper = mockMapper.CreateMapper();

            // Service / Repository
            _repository = new UsersRepository(dbContext);
            
            // Controller
            _usersController = new UsersController(_mockLogger.Object, _repository, _mockMapper, _appSettings);
        }

        [Fact]
        public async void TestGetUsersAsync()
        {
            var actionResult = await _usersController.GetUsersAsync();

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200 ? true : false;
            Assert.True(IsValid);

            var userDto = (HashSet<UserDto>)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDto.Count > 0 ? true : false;

            Assert.True(IsValid);
        }

        [Fact]
        public void TestGetUsers()
        {
            var actionResult = _usersController.GetUsers();

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200 ? true : false;
            Assert.True(IsValid);

            var userDtoList = (HashSet<UserDto>)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDtoList.Count > 0 ? true : false;

            Assert.True(IsValid);
        }

        [Fact]
        public void TestAuthenticate()
        {
            var request = new UserDto
            {
                Username = "test",
                Password = "test",
            };

            var actionResult = _usersController.Authenticate(request);

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200 ? true : false;
            Assert.True(IsValid);

            var userDto = (UserDto)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDto.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }
        
    }
}
