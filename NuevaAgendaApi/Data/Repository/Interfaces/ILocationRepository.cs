using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Repository.Interfaces
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        void Create(CreateAndUpdateLocationDTO dto);
        void Update(CreateAndUpdateLocationDTO dto);
        void Delete(int id);
    }
}
