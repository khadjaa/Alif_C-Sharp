using AutoMapper;

using Erm.DataAccess;

namespace Erm.BussinessLayer;

public class RiskProfileInfoProfile : Profile
{
    public RiskProfileInfoProfile()
    {
        CreateMap<RiskProfileInfo, RiskProfile>()
            .ForMember(dest => dest.RiskName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.BusinessProcess, 
                opt => opt.MapFrom(src => new BusinessProcess { Name = src.BusinessProcess, Domain = src.BusinessProcess }));
    }
}
