namespace Erm.DataAccess;

public sealed class RiskProfile 
{
    private int _occurreceProbability;
    private int _potentialBusinessImpact;
    public required string RiskName {get; set;}
    public string? Description {get; set;}
    public required BusinessProcess BusinessProcess {get; set;}
    public required int OccurreceProbability 
    {
        get => _occurreceProbability;
        set => _occurreceProbability = (value < 1 || value > 100) 
            ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
    }
    public required int PotentialBusinessImpact 
    {
        get => _potentialBusinessImpact;
        set => _potentialBusinessImpact = (value < 1 || value > 100) 
            ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
    }
    public string? PotentialSolution {get; set;}
}

