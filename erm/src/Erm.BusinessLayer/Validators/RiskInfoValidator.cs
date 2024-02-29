using System.Data;

using FluentValidation;

namespace Erm.BusinessLayer.Validators;

internal sealed class RiskInfoValidator : AbstractValidator<RiskInfo>
{
    internal RiskInfoValidator()
    {
        RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(prop => prop.Description).NotEmpty().MinimumLength(10).MaximumLength(500);
        RuleFor(prop => prop.OccurrenceProbability).InclusiveBetween(1, 10);
        RuleFor(prop => prop.PotentialBusinessImpact).InclusiveBetween(1, 10);
        RuleFor(prop => prop.Type).NotEmpty();
    }
}