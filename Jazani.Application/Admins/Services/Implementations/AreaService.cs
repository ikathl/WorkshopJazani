﻿using AutoMapper;
using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Application.Cores.Exceptions;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;
namespace Jazani.Application.Admins.Services.Implementations
{
    internal class AreaService:IAreaService
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AreaService> _logger;
        public AreaService(IAreaRepository AreaRepository, IMapper mapper,ILogger<AreaService> logger)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AreaSimpleDto> CreateAsync(AreaSaveDto saveDto)
        {
            Area Area = _mapper.Map<Area>(saveDto);
            Area.RegistrationDate = DateTime.Now;
            Area.State = true;

            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaSimpleDto AreaDto = _mapper.Map<AreaSimpleDto>(AreaSaved);
            return AreaDto;
        }

        public async Task<AreaSimpleDto> DisabledAsync(int id)
        {
            Area? Area = await _AreaRepository.FindByIdAsync(id);
            _logger.LogInformation("area:" + Area);
            if (Area == null)
            {
                //completar
                _logger.LogInformation("No se encontro un registro de Area para el id:" + id);
            }
            Area.State = false;
            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaSimpleDto AreaDto = _mapper.Map<AreaSimpleDto>(AreaSaved);
            return AreaDto;
        }

        public async Task<AreaSimpleDto> EditAsync(int id, AreaSaveDto saveDto)
        {
            Area? Area = await _AreaRepository.FindByIdAsync(id);
            
            if (Area == null)
            {
                //completar
                throw AreaNotFoundException(id);
            }
            _mapper.Map<AreaSaveDto, Area>(saveDto, Area);
            Area AreaSaved = await _AreaRepository.SaveAsync(Area);
            AreaSimpleDto AreaDto = _mapper.Map<AreaSimpleDto>(AreaSaved);
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
            Area? area = await _AreaRepository.FindByIdAsync(id);
            _logger.LogInformation("area:" + area?.Id);
            if (area == null)
            {
                throw AreaNotFoundException(id);
                _logger.LogWarning("[Area Service]-[FindIdAsync]: No se encontro un registro de Area para el id:" + id);
            }
            AreaDto AreaDto = _mapper.Map<AreaDto>(area);
            return AreaDto;
        }
        private NotFoundCoreException AreaNotFoundException(int id)
        {
            return new NotFoundCoreException("No se encontro el registro de Tipo");
        }
    }
}
