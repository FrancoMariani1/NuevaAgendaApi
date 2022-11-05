using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;

namespace NuevaAgendaApi.Data.Repository
{
    public class UserRepository
    {
        public static List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Email = "asdas@hotmail.com",
                Name = "Pepe",
                Password = "passwordsegura",
                Id = 1,
            },

            new User()
            {
                Email = "lkjb@hotmail.com",
                Name = "Andres",
                Password = "passwordsegura1",
                Id = 2,
            }
        };

        public List<User> GetAllUsers()
        {
            return FakeUsers;
        }

        public bool CreateUser(UserForCreationDTO userDTO)
        {
            User user = new User()
            {
                Name = userDTO.Name,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                UserName = userDTO.UserName,
                Id = userDTO.Id,
            };

            FakeUsers.Add(user);
            return true;
        }
    }
}
