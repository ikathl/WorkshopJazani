using Jazani.Application.Mcs.Dtos.Agreements;

namespace Jazani.Application.Mcs.Services
{
    public interface IAgreementService
    {
        Task<IReadOnlyList<AgreementSmallDto>> FindAllAsync();
        Task<AgreementDto> FindByIdAsync(int id);
        Task<AgreementSimpleDto> CreateAsync(AgreementSaveDto saveDto);
        Task<AgreementSimpleDto> EditAsync(int id, AgreementSaveDto saveDto);
        Task<AgreementSimpleDto> DisabledAsync(int id);
    }
}
