using Erm.BusinessLayer;
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
            OccurreceProbability = profileInfo.OccurrenceProbability,
            PotentialBusinessImpact = profileInfo.PotentialBusinessImpact,
            Risk = new Risk 
            {
                Name = profileInfo.Risk, 
                Description = profileInfo.Risk, 
                OccurrenceProbability = profileInfo.OccurrenceProbability, 
                PotentialBusinessImpact = profileInfo.PotentialBusinessImpact, 
                Type = (RiskType)profileInfo.Type
            }
        };
    }
}