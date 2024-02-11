using AutoMapper;
using Erm.DataAccess;

namespace Erm.BussinessLayer;

internal static class AutoMapper 
{
    internal readonly static MapperConfiguration MapperConfiguration = new( opt => {
            opt.AddProfile<RiskProfileInfoProfile>();
            opt.AddProfile<RiskInfoProfile>();
    });
}