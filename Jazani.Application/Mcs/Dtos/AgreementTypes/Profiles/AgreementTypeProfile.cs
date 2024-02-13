using AutoMapper;
using Jazani.Application.Mcs.Dtos.AgreementTypes;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.AgreementTypeTypes.Profiles
{
    public class AgreementTypeProfile : Profile
    {
        public AgreementTypeProfile()
        {
            CreateMap<AgreementType, AgreementTypeDto>();
            CreateMap<AgreementType, AgreementTypeSmallDto>();
            CreateMap<AgreementType, AgreementTypeSimpleDto>();

            CreateMap<AgreementType, AgreementTypeSaveDto>().ReverseMap();

        }
    }
}
