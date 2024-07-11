using contact_list_backend.Data;
using contact_list_backend.Models;
using contact_list_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contact_list_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Retrieves a list of contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _contactService.GetContactsAsync());
        }

        /// <summary>
        /// Takes in a contact, creates it if valid, and returns the new record
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            try
            {
                return Ok(await _contactService.CreateContactAsync(contact));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Takes in an existing contact, updates it if valid, and returns the updated record
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            try
            {
                return Ok(await _contactService.UpdateContactAsync(contact));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the list of possible contact frequencies for dropdown
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/ContactFrequency")]
        public async Task<IActionResult> ContactFrequencies()
        {
            return Ok(await _contactService.GetContactFrequenciesAsync());
        }
    }
}
