
namespace Jazani.Domain.Mcs.Models
{
    public class AgreementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }

    }
}
