using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;
using NuevaAgendaApi.Models.Enum;

namespace NuevaAgendaApi.Data.Repository.Implementations
{
    public class UserRepository
    {
        private AgendaApiContext _context;
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

        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
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

        public User ValidateUser(string userName, string password)
        {
            var userActual = FakeUsers.Single(u => u.UserName == userName);
            if (userActual.Password == password)
                return userActual;
            return userActual;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
        }

        public void Archive(int Id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (user != null)
            {
                user.state = State.Archived;
                _context.Update(user);
            }
            
        }
    }
}
