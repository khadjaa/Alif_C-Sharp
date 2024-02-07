using FluentValidation.Results;
using Erm.BussinessLayer.Validators;
using System.Diagnostics;
using FluentValidation;

namespace Erm.BussinessLayer;

public sealed class RiskProfileService : IRiskProfileService
{
    public void Create(RiskProfileInfo profileInfo)
    {
        RiskProfileInfoValidator validatorRules = new();
        validatorRules.ValidateAndThrow(profileInfo);
    }
}