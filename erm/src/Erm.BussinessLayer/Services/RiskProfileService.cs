using Erm.BussinessLayer.Validators;

using FluentValidation;

using Erm.DataAccess;

using AutoMapper;

namespace Erm.BussinessLayer;

public sealed class RiskProfileService(
    IValidator<RiskProfileInfo> validator,
    RiskProfileRepositoryProxy profileRepositoryProxy,
    IMapper mapper)
    : IRiskProfileService
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<RiskProfileInfo> _validator = validator;
    private readonly RiskProfileRepositoryProxy _repository = profileRepositoryProxy;

    public async Task<RiskProfileInfo> GetAsync(string riskProfileName, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(riskProfileName);
        return _mapper.Map<RiskProfileInfo>(await _repository.GetAsync(riskProfileName, token));
    }

    public async Task CreateAsync(RiskProfileInfo profileInfo, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(profileInfo, token);

        RiskProfile riskProfile = _mapper.Map<RiskProfile>(profileInfo);

        await _repository.CreateAsync(riskProfile, token);
    }

    public async Task UpdateAsync(string name, RiskProfileInfo profileInfo, CancellationToken token = default)
    {
        RiskProfileInfoValidator validatorRules = new();
        await validatorRules.ValidateAndThrowAsync(profileInfo, token);

        await _repository.UpdateAsync(name,
            new RiskProfile
            {
                RiskName = profileInfo.Name,
                Description = profileInfo.Description,
                BusinessProcess =
                    new BusinessProcess
                    {
                        Name = profileInfo.BusinessProcess, Domain = profileInfo.BusinessProcess
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
            }, token);
    }

    public async Task DeleteAsync(string riskProfileName, CancellationToken token = default)
    {
        await _repository.DeleteAsync(riskProfileName, token);
    }

    public async Task<double> CalculateRiskAsync(string riskProfileName)
    {
        var riskProfile = await _repository.GetAsync(riskProfileName);

        double calculateRisk = riskProfile.OccurreceProbability * riskProfile.PotentialBusinessImpact;

        return calculateRisk;
    }

    public async Task<IEnumerable<RiskProfileInfo>> QueryAsync(string query, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(query);

        IEnumerable<RiskProfile> riskProfiles = await _repository.GetAllAsync(query, token);

        return _mapper.Map<IEnumerable<RiskProfileInfo>>(riskProfiles);
    }
}