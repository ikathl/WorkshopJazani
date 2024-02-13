using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.Agreements;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using System.Diagnostics.Contracts;

namespace Jazani.Application.Mcs.Services.Implementations
{
    internal class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IMapper _mapper;


        public AgreementService(IAgreementRepository agreementRepository, IMapper mapper)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<AgreementSmallDto>> FindAllAsync()
        {
            var agreements = await _agreementRepository
                .FindAllAsync(predicate: x => x.State == true);

            return _mapper.Map<IReadOnlyList<AgreementSmallDto>>(agreements);
        }

        public async Task<AgreementDto> FindByIdAsync(int id)
        {
            var agreement = await _agreementRepository.FindByIdAsync(id);

            if (agreement == null)
            {
                throw AgreementNotFound(id);
            }

            return _mapper.Map<AgreementDto>(agreement);
        }

        public async Task<AgreementSimpleDto> CreateAsync(AgreementSaveDto saveDto)
        {
            var agreement = _mapper.Map<Agreement>(saveDto);
            agreement.Contractid = 1025;
            agreement.Holderid = 4;
            agreement.RegistrationDate = DateTime.Now;
            agreement.State = true;

            await _agreementRepository.SaveAsync(agreement);

            return _mapper.Map<AgreementSimpleDto>(agreement);
        }

        public async Task<AgreementSimpleDto> EditAsync(int id, AgreementSaveDto saveDto)
        {
            var agreement = await _agreementRepository.FindByIdAsync(id);

            if (agreement == null)
            {
                throw AgreementNotFound(id);
            }

            _mapper.Map<AgreementSaveDto, Agreement>(saveDto, agreement);

            await _agreementRepository.SaveAsync(agreement);

            return _mapper.Map<AgreementSimpleDto>(agreement);
        }

        public async Task<AgreementSimpleDto> DisabledAsync(int id)
        {
            var agreement = await _agreementRepository.FindByIdAsync(id);
            agreement.State = false;

            await _agreementRepository.SaveAsync(agreement);

            return _mapper.Map<AgreementSimpleDto>(agreement);
        }

        private NotFoundCoreException AgreementNotFound(int id)
        {
            return new NotFoundCoreException($"Agreement no encontrado con el id {id}.");
        }

    }
}