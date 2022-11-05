using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Repository
{
    public class ContactRepository
    {

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

        public List<Contact> GetAllContacts()
        {
            return FakeContacts;
        }

        public bool CreateContact(ContactForCreationDTO contactDTO)
        {
            Contact contact = new Contact()
            {
                Name = contactDTO.Name,
                CelularNumber = contactDTO.CelularNumber,
                TelephoneNumber = contactDTO.TelephoneNumber,
                Id = contactDTO.Id,
                Description = contactDTO.Description,
                Email = contactDTO.Email,

            };

            FakeContacts.Add(contact);
            return true;
        }
    }
}
