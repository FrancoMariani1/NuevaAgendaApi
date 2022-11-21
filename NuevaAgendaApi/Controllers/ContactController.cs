using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuevaAgendaApi.Data.Interfaces;
using NuevaAgendaApi.Data.Repository.Implementations;
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

        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;


        public ContactController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        //public static List<Contact> FakeContacts = new List<Contact>()
        //{
        //    new Contact()
        //    {
        //        Id = 1,
        //        Name = "Franco",
        //        CelularNumber = 155555555,
        //    },

        //    new Contact()
        //    {
        //        Id = 2,
        //        Name = "Tadeo",
        //        CelularNumber = 155444444

        //    }
        //};
        [HttpGet]
        //[Route("GetAll/{}")]
        
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAll());
        }

        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            List<Contact> contactsToReturn = _contactRepository.GetAll();
            contactsToReturn.Where(x => x.Id == Id).ToList();
            if (contactsToReturn.Count > 0)
                return Ok(contactsToReturn);
            return NotFound("Contacto inexistente");
        }

        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContactDTO contactDTO)
        {
            _contactRepository.Create(contactDTO);
            return NoContent();
        }

        //[HttpDelete]
        //public IActionResult DeleteContactById(int id)
        //{
        //    try
        //    {
        //        _contactRepository.Delete(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult DeleteContactById(int Id)
        //{
        //    try
        //    {
        //        _contactRepository.Delete(Id);
                
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(int Id)
        //{
        //    try
        //    {
        //        string role = HttpContext.User.FindFirst("role").Value;
        //        if (role == "Admin")
        //        {
        //            _userRepository.Delete(Id);
                
        //        }
        //        else
        //        {
        //            _userRepository.Archive(Id);
        //        }
        //        return NoContent();
                
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "Admin")
                {
                    _userRepository.Delete(Id);

                }
                else
                {
                    _userRepository.Archive(Id);
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        }
}
