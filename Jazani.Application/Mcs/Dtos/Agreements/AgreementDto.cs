using Jazani.Application.Mcs.Dtos.AgreementTypes;

namespace Jazani.Application.Mcs.Dtos.Agreements
{
    public class AgreementDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        //Relations
        public virtual AgreementTypeSmallDto AgreementType { get; set; }
    }
}
