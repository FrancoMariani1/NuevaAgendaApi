using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuevaAgendaApi.Data.Repository;
using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        //public List<Contact> contacts = new List<Contact>()
        //{
        //    new Contact(){Name = "Franco", CelularNumber = 155555555},
        //    new Contact(){Name = "Tadeo", CelularNumber = 155444444, TelephoneNumber = 4555555, Description = "Hijo"}
        //};

        private ContactRepository _contactRepository { get; set;}

        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository; 
        }

        public static List<Contact> FakeContacts = new List<Contact>()
        {
            new Contact()
            {
                Id = 1,
                Name = "Franco",
                CelularNumber = 155555555,
            },

            new Contact()
            {
                Id = 2,
                Name = "Tadeo",
                CelularNumber = 155444444

            }
        };
        [HttpGet]
        //[Route("GetAll/{}")]
        
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAllContacts());
        }

        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<Contact> contactsToReturn = _contactRepository.GetAllContacts();
            contactsToReturn.Where(x => x.Id == Id).ToList();
            if (contactsToReturn.Count > 0)
                return Ok(contactsToReturn);
            return NotFound("Contacto inexistente");
        }

        [HttpPost]
        public IActionResult CreateContact(ContactForCreationDTO contactDTO)
        {
            _contactRepository.CreateContact(contactDTO);
            return NoContent();
        }

    }
}
