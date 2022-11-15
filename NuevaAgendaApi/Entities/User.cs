using NuevaAgendaApi.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuevaAgendaApi.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public State state { get; set; } = State.Active;
        public Rol Rol { get; set; } = Rol.User;
    }
}
