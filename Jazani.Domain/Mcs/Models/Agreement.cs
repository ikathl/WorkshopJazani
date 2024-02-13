namespace Jazani.Domain.Mcs.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public int AgreementTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public int Contractid { get; set; }
        public int Holderid { get; set; }
        //relations
        public virtual AgreementType AgreementType { get; set; }
    }
}
