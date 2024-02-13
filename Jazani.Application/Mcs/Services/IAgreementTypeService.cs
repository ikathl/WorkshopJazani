using Jazani.Application.Mcs.Dtos.AgreementTypes;

namespace Jazani.Application.Mcs.Services
{
    public interface IAgreementTypeService
    {
        Task<IReadOnlyList<AgreementTypeSmallDto>> FindAllAsync();
        Task<AgreementTypeDto> FindByIdAsync(int id);
        Task<AgreementTypeSimpleDto> CreateAsync(AgreementTypeSaveDto saveDto);
        Task<AgreementTypeSimpleDto> EditAsync(int id, AgreementTypeSaveDto saveDto);
        Task<AgreementTypeSimpleDto> DisabledAsync(int id);
    }
}
