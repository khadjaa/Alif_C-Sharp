using AutoMapper;

using Erm.DataAccess;

namespace Erm.BussinessLayer;

public class RiskProfileInfoProfile : Profile
{
    public RiskProfileInfoProfile()
    {
        CreateMap<RiskProfileInfo, RiskProfile>()
            .ForMember(dest => dest.RiskName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Risk, 
                opt => opt.MapFrom(src => new Risk 
                { 
                    Name = src.Risk, 
                    Description = src.Risk, 
                    OccurrenceProbability = src.OccurreceProbability, 
                    PotentialBusinessImpact = src.PotentialBusinessImpact, 
                    Type = (RiskType)src.Type 
                }))
            .ForMember(dest => dest.BusinessProcess, 
                opt => opt.MapFrom(src => new BusinessProcess { Name = src.BusinessProcess, Domain = src.BusinessProcess }));
    }
}
