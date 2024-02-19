namespace Erm.DataAccess;

public enum RiskType
{
    Financial,
    Technical,
    Reputation,
}

public class Risk
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public required string Description { get; set; } 
    public RiskType Type { get; set; }
    public int OccurrenceProbability { get; set; } 
    public int PotentialBusinessImpact { get; set; }
    public DateTime? OccurrenceDate { get; set; }
    public string? PotentialSolution { get; set; }
}