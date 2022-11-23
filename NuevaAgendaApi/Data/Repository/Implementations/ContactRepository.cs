using AutoMapper;
using NuevaAgendaApi.Data.Interfaces;
using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private AgendaApiContext _context;
        private readonly IMapper _mapper;


        public ContactRepository(AgendaApiContext context)
        {
            _context = context;
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

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public void Create(CreateAndUpdateContactDTO dto)
        {

        }
        //public bool CreateContact(ContactForCreationDTO contactDTO)
        //{
        //    Contact contact = new Contact()
        //    {
        //        Name = contactDTO.Name,
        //        CelularNumber = contactDTO.CelularNumber,
        //        TelephoneNumber = contactDTO.TelephoneNumber,
        //        Id = contactDTO.Id,
        //        Description = contactDTO.Description,
        //        Email = contactDTO.Email,

        //    };

        //    FakeContacts.Add(contact);
        //    return true;
        //}
        public void Update(CreateAndUpdateContactDTO dto)
        {

        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
        }
    }
}
