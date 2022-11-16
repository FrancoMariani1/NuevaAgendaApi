using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Interfaces
{
    public interface IUserRepository
    {
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
        User? GetById(int UserId);
        List<User> GetAll();
        void Create(CreateAndUpdateUserDTO dto);
        void Update(CreateAndUpdateUserDTO dto);
        void Delete(int Id);
        void Archive(int Id);

    }
}
