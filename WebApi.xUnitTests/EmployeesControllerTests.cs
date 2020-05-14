using AutoMapper;
using Domain.Helpers;
using Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApi.xUnitTests
{
    public class EmployeesControllerTests
    {
        // AAA pattern
        // 1. Arrange: Prepare for the test 
        // 2. Act: Run the SUT (Software Under Test - the actual testing code)
        // 3. Assert: Check and verify the result.

        private readonly Mock<ILogger<EmployeesController>> _mockLogger;
        private readonly IMapper _mockMapper;
        private readonly IEmployeesRepository _repository;
        private readonly EmployeesController _employeesController;

        public EmployeesControllerTests()
        {
            // 1. Arrange: Prepare for the test 

            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger
            _mockLogger = new Mock<ILogger<EmployeesController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            // Mapper
            _mockMapper = mockMapper.CreateMapper();

            // Service / Repository
            _repository = new EmployeesRepository(dbContext);

            // Controller
            _employeesController = new EmployeesController(_mockLogger.Object, _repository, _mockMapper);
        }

        #region << GET >>



        #endregion

        #region << GET BY ID >>



        #endregion

        #region << GET - SEARCHER >>



        #endregion

        #region << CREATE - POST >>



        #endregion

        #region << UPDATE - PUT >>



        #endregion

        #region << DELETE >>



        #endregion

    }
}
