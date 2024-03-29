using Erm.BussinessLayer.Validators;
using FluentValidation;
using Erm.DataAccess;
using AutoMapper;

namespace Erm.BussinessLayer;

public sealed class RiskProfileService : IRiskProfileService
{
    private readonly IRiskProfileRepository _riskProfileRepository;
    private readonly IMapper _mapper;
    private readonly RiskProfileInfoValidator _validationRules;
    public RiskProfileService()
    {
        _riskProfileRepository = new RiskProfileRepository();
        _mapper = AutoMapper.MapperConfiguration.CreateMapper();
        _validationRules = new();
    }

    public RiskProfile Get(string riskProfileName)
    {
        return _riskProfileRepository.Get(riskProfileName);
    }

    public void Create(RiskProfileInfo profileInfo)
    {
        _validationRules.ValidateAndThrow(profileInfo);

        RiskProfile riskProfile = _mapper.Map<RiskProfile>(profileInfo);

        _riskProfileRepository.Create(riskProfile);
    }

    public void Update(string name, RiskProfileInfo profileInfo)
    {
        RiskProfileInfoValidator validatorRules = new();
        validatorRules.ValidateAndThrow(profileInfo);

        _riskProfileRepository.Update(name, new RiskProfile
        {
            RiskName = profileInfo.Name,
            Description = profileInfo.Description,
            BusinessProcess = new BusinessProcess 
            { 
                Name = profileInfo.BusinessProcess, 
                Domain = profileInfo.BusinessProcess 
            },
            OccurreceProbability = profileInfo.OccurreceProbability,
            PotentialBusinessImpact = profileInfo.PotentialBusinessImpact,
            Risk = new Risk 
            {
                 Name = profileInfo.Risk, 
                 Description = profileInfo.Risk, 
                 OccurrenceProbability = profileInfo.OccurreceProbability, 
                 PotentialBusinessImpact = profileInfo.PotentialBusinessImpact, 
                 Type = (RiskType)profileInfo.Type
            }
        });
    }

    public void Delete(string riskProfileName)
    {
        _riskProfileRepository.Delete(riskProfileName);
    }

    public double CalculateRisk(string riskProfileName)
    {
        var riskProfile = _riskProfileRepository.Get(riskProfileName);

        double calculateRiskrisk = riskProfile.OccurreceProbability * riskProfile.PotentialBusinessImpact;

        return calculateRiskrisk;
    }

    public IEnumerable<RiskProfileInfo> Query(string query)
    {
        ArgumentException.ThrowIfNullOrEmpty(query);

        IEnumerable<RiskProfile> riskProfiles = _riskProfileRepository.GetAll(query);

        return _mapper.Map<IEnumerable<RiskProfileInfo>>(riskProfiles);
    }
}