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


        public ContactRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public List<Contact> GetAll(int id)
        {
            return _context.Contacts.Where(c => c.UserId == id).ToList();
        }

        public void Create(CreateAndUpdateContactDTO dto, int id)
        {
            Contact contact = _mapper.Map<Contact>(dto);
            contact.UserId = id;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
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
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }
    }
}
