namespace Erm.BussinessLayer;
public readonly record struct RiskInfo(
    string Name,
    string Description,
    string Type,
    int OccurrenceProbability,
    int PotentialBusinessImpact
);