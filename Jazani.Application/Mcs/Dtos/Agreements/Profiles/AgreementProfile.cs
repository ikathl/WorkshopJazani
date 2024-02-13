using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.Agreements.Profiles
{
    public class AgreementProfile:Profile
    {
        public AgreementProfile()
        {
            CreateMap<Agreement, AgreementDto>();
            CreateMap<Agreement, AgreementSmallDto>();
            CreateMap<Agreement, AgreementSimpleDto>();

            CreateMap<Agreement, AgreementSaveDto>().ReverseMap();
        }
    }
}
