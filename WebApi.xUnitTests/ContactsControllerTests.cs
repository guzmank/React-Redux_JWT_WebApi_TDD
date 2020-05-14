using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Controllers;
using Xunit;

namespace WebApi.xUnitTests
{
    public class ContactsControllerTests
    {
        private readonly Mock<ILogger<ContactsController>> _mockLogger;
        private readonly IMapper _mockMapper;
        private readonly IContactsRepository _repository;
        private readonly ContactsController _contactsController;

        public ContactsControllerTests()
        {
            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger
            _mockLogger = new Mock<ILogger<ContactsController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            // Mapper
            _mockMapper = mockMapper.CreateMapper();

            // Service / Repository
            _repository = new ContactsRepository(dbContext);

            // Controller
            _contactsController = new ContactsController(_mockLogger.Object, _repository, _mockMapper);
        }

        #region << GET ALL >>

        [Fact]
        public async void TestGetContactsAsync()
        {
            var data = await _contactsController.GetContactsAsync();
            
            Assert.IsAssignableFrom<List<ContactsDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        #endregion

    }
}
