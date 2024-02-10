using AutoMapper;
using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    internal class AreaService:IAreaService
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;
        public AreaService(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<AreaDto> CreateAsync(AreaSaveDto saveDto)
        {
            Area Area = _mapper.Map<Area>(saveDto);
            Area.RegistrationDate = DateTime.Now;
            Area.State = true;

            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaDto AreaDto = _mapper.Map<AreaDto>(AreaSaved);
            return AreaDto;
        }

        public async Task<AreaDto> DisabledAsync(int id)
        {
            Area? Area = await _AreaRepository.FindByIdAsync(id);
            if (Area == null)
            {
                //completar
            }
            Area.State = false;
            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaDto AreaDto = _mapper.Map<AreaDto>(AreaSaved);
            return AreaDto;
        }

        public async Task<AreaDto> EditAsync(int id, AreaSaveDto saveDto)
        {
            Area? Area = await _AreaRepository.FindByIdAsync(id);
            if (Area == null)
            {
                //completar
            }
            _mapper.Map<AreaSaveDto, Area>(saveDto, Area);
            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaDto AreaDto = _mapper.Map<AreaDto>(AreaSaved);
            return AreaDto;
        }

        public async Task<IReadOnlyList<AreaSmallDto>> FindAllAsync()
        {
            IReadOnlyList<Area> Areas = await _AreaRepository.FindAllAsync();
            IReadOnlyList<AreaSmallDto> AreaDtos = _mapper.Map<IReadOnlyList<AreaSmallDto>>(Areas);
            return AreaDtos;
        }

        public async Task<AreaDto> FindByIdAsync(int id)
        {
            Area? Area = await _AreaRepository.FindByIdAsync(id);
            if (Area == null)
            {
                //completar
            }
            AreaDto AreaDto = _mapper.Map<AreaDto>(Area);
            return AreaDto;
        }
    }
}
