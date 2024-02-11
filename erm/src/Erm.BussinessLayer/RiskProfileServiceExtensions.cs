using Erm.BussinessLayer;
using Erm.DataAccess;

internal static class RiskProfileServiceExtensions
{
    public static RiskProfile ToRiskProfile(this RiskProfileInfo profileInfo) 
    {
        return new RiskProfile
        {
            RiskName = profileInfo.Name,
            Description = profileInfo.Description,
            BusinessProcess = new BusinessProcess 
            { 
                Name = profileInfo.BusinessProcess, 
                Domain = profileInfo.BusinessProcess 
            },
            OccurreceProbability = profileInfo.OccurreceProbability,
            PotentialBusinessImpact = profileInfo.PotentialBusinessImpact
        };
    }
}