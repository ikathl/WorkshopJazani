using AutoMapper;
using Jazani.Application.Admins.Dtos.AreaTypes;
using Jazani.Application.Admins.Dtos.AreaTypes;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class AreaTypeService : IAreaTypeService
    {
        private readonly IAreaTypeRepository _areaTypeRepository;
        private readonly IMapper _mapper;
        public AreaTypeService(IAreaTypeRepository areaTypeRepository,IMapper mapper) {
            _areaTypeRepository = areaTypeRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync()
        {
            IReadOnlyList<AreaType> areaTypes = await _areaTypeRepository.FindAllAsync();
            IReadOnlyList<AreaTypeSmallDto> areaTypeDtos = _mapper.Map<IReadOnlyList<AreaTypeSmallDto>>(areaTypes);
            return areaTypeDtos;
        }

        public async Task<AreaTypeDto> FindByIdAsync(int id)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);
            if(areaType == null)
            {
                //completar
            }
            AreaTypeDto areaTypeDto=_mapper.Map<AreaTypeDto>(areaType);
            return areaTypeDto;
        }
    }
}
