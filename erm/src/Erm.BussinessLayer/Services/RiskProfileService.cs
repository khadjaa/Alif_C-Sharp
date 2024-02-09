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

    public RiskProfile Get(string riskProfileName)
    {
        return _riskProfileRepository.Get(riskProfileName);
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

    public void Update(string name, RiskProfileInfo profileInfo)
    {
        RiskProfileInfoValidator validatorRules = new();
        validatorRules.ValidateAndThrow(profileInfo);

        _riskProfileRepository.Update(name, new RiskProfile
        {
            RiskName = profileInfo.Name,
            Description = profileInfo.Description,
            BusinessProcess = new BusinessProcess { Name = profileInfo.BusinessProcess, Domain = profileInfo.BusinessProcess },
            OccurreceProbability = profileInfo.OccurreceProbability,
            PotentialBusinessImpact = profileInfo.PotentialBusinessImpact
        });
    }

    public void Delete(string riskProfileName)
    {
        _riskProfileRepository.Delete(riskProfileName);
    }
}