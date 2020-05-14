using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        protected readonly ILogger _logger;
        private IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;

        public ContactsController(ILogger<ContactsController> logger, IContactsRepository contactRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _contactsRepository = contactRepository;
        }

        [HttpGet]
        [Route("Contacts")]
        public async Task<List<ContactsDto>> GetContactsAsync()
        {
            var response = new List<ContactsDto>();

            var serviceResponse = await _contactsRepository.GetContacts();

            response = _mapper.Map<List<ContactsDto>>(serviceResponse);

            return response;
        }

        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact([FromBody] ContactsDto contactsDto)
        {
            var serviceResponse = await _contactsRepository.SaveContact(_mapper.Map<Contacts>(contactsDto));
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            var serviceResponse = await _contactsRepository.DeleteContact(contactId);
            return Ok(serviceResponse);
        }

    }
}