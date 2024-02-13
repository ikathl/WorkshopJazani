namespace Jazani.Application.Mcs.Dtos.Agreements
{
    public class AgreementSaveDto
    {
        public int AgreementTypeId { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
