using NuevaAgendaApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace NuevaAgendaApi.Dto
{
    public class CreateAndUpdateContactDTO
    {
        [Required]
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public string Description = String.Empty;
        public User? User;
        
    }
}
