using Jazani.Application.Admins.Dtos.Areas;

namespace Jazani.Application.Admins.Services
{
    public interface IAreaService
    {
        Task<IReadOnlyList<AreaSmallDto>> FindAllAsync();
        Task<AreaDto> FindByIdAsync(int id);
        Task<AreaSimpleDto> CreateAsync(AreaSaveDto AreaSmallDto);
        Task<AreaSimpleDto> EditAsync(int id, AreaSaveDto AreaSaveDto);
        Task<AreaSimpleDto> DisabledAsync(int id);

    }
}
