namespace Jazani.Application.Admins.Dtos.Areas
{
    public class AreaSaveDto
    {
        public int AreaTypeId { get; set; }
        public string Name { get; set; } = default!;//obligatorio que tenga un valor
        public string? Description { get; set; }
        public int contractid { get; set; } = 1025;
        public int holderid { get; set; } = 4;

    }
}
