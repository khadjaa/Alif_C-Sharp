using AutoMapper;

namespace Erm.BusinessLayer;

internal static class AutoMapper 
{
    internal readonly static MapperConfiguration MapperConfiguration = new( opt => {
            opt.AddProfile<RiskProfileInfoProfile>();
            opt.AddProfile<RiskInfoProfile>();
    });
}