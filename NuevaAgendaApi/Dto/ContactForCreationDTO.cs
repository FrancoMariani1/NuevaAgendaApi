namespace NuevaAgendaApi.Dto
{
    public class ContactForCreationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int? TelephoneNumber { get; set; }
        public int CelularNumber { get; set; }
        public string? Description { get; set; }
        
    }
}
