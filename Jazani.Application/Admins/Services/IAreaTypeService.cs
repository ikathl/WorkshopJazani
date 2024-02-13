using Jazani.Application.Admins.Dtos.AreaTypes;

namespace Jazani.Application.Admins.Services
{
    public interface IAreaTypeService
    {
        Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync();
        Task<AreaTypeDto> FindByIdAsync(int id);
        Task<AreaTypeSimpleDto> CreateAsync(AreaTypeSaveDto areaTypeSmallDto);
        Task<AreaTypeSimpleDto> EditAsync(int id, AreaTypeSaveDto areaTypeSaveDto);
        Task<AreaTypeSimpleDto> DisabledAsync(int id);

    }
}
