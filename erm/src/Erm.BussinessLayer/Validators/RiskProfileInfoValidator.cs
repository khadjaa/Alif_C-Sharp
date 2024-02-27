using FluentValidation;

namespace Erm.BussinessLayer.Validators;

public sealed class RiskProfileInfoValidator : AbstractValidator<RiskProfileInfo>
{
    public RiskProfileInfoValidator()
    {
        RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(prop => prop.Description).NotEmpty().MinimumLength(10).MaximumLength(500);
        RuleFor(prop => prop.BusinessProcess).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(prop => prop.OccurreceProbability).InclusiveBetween(1, 10);
        RuleFor(prop => prop.PotentialBusinessImpact).InclusiveBetween(1, 10);
    }
}