namespace Jazani.Application.Admins.Dtos.AreaTypes
{
    public class AreaTypeSaveDto
    {
        public string Name { get; set; } = default!;//obligatorio que tenga un valor
        public string? Description { get; set; }
        
    }
}
