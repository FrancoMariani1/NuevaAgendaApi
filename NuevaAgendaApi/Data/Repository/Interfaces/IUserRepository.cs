using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public User? GetById(int UserId);
        public List<User> GetAll();
        public void Create(CreateAndUpdateUserDTO dto);
        public void Update(CreateAndUpdateUserDTO dto);
        public void Delete(int Id);
        public void Archive(int Id);

    }
}
