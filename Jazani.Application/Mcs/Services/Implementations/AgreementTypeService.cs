using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.AgreementTypes;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class AgreementTypeService : IAgreementTypeService
    {
        private readonly IAgreementTypeRepository _agreementTypeRepository;
        private readonly IMapper _mapper;


        public AgreementTypeService(IAgreementTypeRepository agreementTypeRepository, IMapper mapper)
        {
            _agreementTypeRepository = agreementTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<AgreementTypeSmallDto>> FindAllAsync()
        {
            var agreementTypes = await _agreementTypeRepository
                .FindAllAsync(predicate: x => x.State == true);

            return _mapper.Map<IReadOnlyList<AgreementTypeSmallDto>>(agreementTypes);
        }

        public async Task<AgreementTypeDto> FindByIdAsync(int id)
        {
            var agreementType = await _agreementTypeRepository.FindByIdAsync(id);

            if (agreementType == null)
            {
                throw AgreementTypeNotFound(id);
            }

            return _mapper.Map<AgreementTypeDto>(agreementType);
        }

        public async Task<AgreementTypeSimpleDto> CreateAsync(AgreementTypeSaveDto saveDto)
        {
            var agreementType = _mapper.Map<AgreementType>(saveDto);
            agreementType.RegistrationDate = DateTime.Now;
            agreementType.State = true;

            await _agreementTypeRepository.SaveAsync(agreementType);

            return _mapper.Map<AgreementTypeSimpleDto>(agreementType);
        }

        public async Task<AgreementTypeSimpleDto> EditAsync(int id, AgreementTypeSaveDto saveDto)
        {
            var agreementType = await _agreementTypeRepository.FindByIdAsync(id);

            if (agreementType == null)
            {
                throw AgreementTypeNotFound(id);
            }

            _mapper.Map<AgreementTypeSaveDto, AgreementType>(saveDto, agreementType);

            await _agreementTypeRepository.SaveAsync(agreementType);

            return _mapper.Map<AgreementTypeSimpleDto>(agreementType);
        }

        public async Task<AgreementTypeSimpleDto> DisabledAsync(int id)
        {
            var agreementType = await _agreementTypeRepository.FindByIdAsync(id);
            agreementType.State = false;

            await _agreementTypeRepository.SaveAsync(agreementType);

            return _mapper.Map<AgreementTypeSimpleDto>(agreementType);
        }

        private NotFoundCoreException AgreementTypeNotFound(int id)
        {
            return new NotFoundCoreException($"AgreementType no encontrado con el id {id}.");
        }

    }
}
