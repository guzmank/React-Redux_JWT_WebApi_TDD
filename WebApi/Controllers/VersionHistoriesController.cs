using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionHistoriesController : ControllerBase
    {
        protected readonly ILogger _logger;
        private IMapper _mapper;
        private readonly IVersionHistoriesRepository _versionHistoriesRepository;

        public VersionHistoriesController(ILogger<VersionHistoriesController> logger, IVersionHistoriesRepository versionHistoriesRepository, IMapper mapper)
        {
            _logger = logger;
            _versionHistoriesRepository = versionHistoriesRepository;
            _mapper = mapper;
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