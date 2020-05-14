using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        protected readonly ILogger _logger;
        private IMapper _mapper;
        private IUsersRepository _userRepository;
        private readonly IOptions<AppSettings> _appSettings;

        public UsersController(ILogger<UsersController> logger, IUsersRepository userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userService;
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var response = new UserDto();

            var serviceResponse = _userRepository.Authenticate(userDto.Username, GenericService.Encrypt(userDto.Password, _appSettings.Value.KeyForEncrypting));

            if (serviceResponse == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, serviceResponse.UniqueId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            serviceResponse.Token = tokenHandler.WriteToken(token);
            
            response = _mapper.Map<UserDto>(serviceResponse);

            return Ok(response);
        }
        
        [HttpGet]
        [Route("GetUsersAsync")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var response = new HashSet<UserDto>();

            var serviceResponse = await _userRepository.GetUsersAsync();

            response = _mapper.Map<HashSet<UserDto>>(serviceResponse);

            return Ok(response);
        }
        
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var response = new HashSet<UserDto>();

            var serviceResponse = _userRepository.GetUsersAsync().Result;

            response = _mapper.Map<HashSet<UserDto>>(serviceResponse);

            return Ok(response);
        }

    }
}