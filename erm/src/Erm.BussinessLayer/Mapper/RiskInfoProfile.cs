using AutoMapper;

using Erm.DataAccess;

namespace Erm.BussinessLayer;

public class RiskInfoProfile : Profile
{
    public RiskInfoProfile()
    {
        CreateMap<RiskInfo, Risk>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.OccurrenceProbability, opt => opt.MapFrom(src => src.OccurrenceProbability))    
            .ForMember(dest => dest.PotentialBusinessImpact, opt => opt.MapFrom(src => src.PotentialBusinessImpact))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
}
