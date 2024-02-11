namespace Erm.BussinessLayer;
public readonly record struct RiskProfileInfo(
    string Name,
    string Description,
    string BusinessProcess,
    int OccurreceProbability,
    int PotentialBusinessImpact,
    string Risk,
    int Type
);