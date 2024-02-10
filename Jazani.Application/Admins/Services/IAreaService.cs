using Jazani.Application.Admins.Dtos.Areas;

namespace Jazani.Application.Admins.Services
{
    public interface IAreaService
    {
        Task<IReadOnlyList<AreaSmallDto>> FindAllAsync();
        Task<AreaDto> FindByIdAsync(int id);
        Task<AreaDto> CreateAsync(AreaSaveDto AreaSmallDto);
        Task<AreaDto> EditAsync(int id, AreaSaveDto AreaSaveDto);
        Task<AreaDto> DisabledAsync(int id);
    }
}
