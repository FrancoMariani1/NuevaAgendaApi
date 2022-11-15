using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();
        public void Create(CreateAndUpdateContactDTO dto);
        public void Update(CreateAndUpdateContactDTO dto);
        public void Delete(int id);


    }
}
