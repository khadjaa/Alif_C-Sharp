using Erm.BussinessLayer.Validators;
using FluentValidation;
using Erm.DataAccess;

namespace Erm.BussinessLayer;

public sealed class RiskProfileService : IRiskProfileService
{
    private readonly IRiskProfileRepository _riskProfileRepository;

    public RiskProfileService()
    {
        _riskProfileRepository = new RiskProfileRepository();
    }

    public void Create(RiskProfileInfo profileInfo)
    {
        RiskProfileInfoValidator validatorRules = new();
        validatorRules.ValidateAndThrow(profileInfo);

        _riskProfileRepository.Create(new RiskProfile
        {
            RiskName = profileInfo.Name,
            Description = profileInfo.Description,
            BusinessProcess = new BusinessProcess { Name = profileInfo.BusinessProcess, Domain = profileInfo.BusinessProcess },
            OccurreceProbability = profileInfo.OccurreceProbability,
            PotentialBusinessImpact = profileInfo.PotentialBusinessImpact
        });
    }
}