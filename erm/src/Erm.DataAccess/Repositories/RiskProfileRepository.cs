namespace Erm.DataAccess;

public sealed class RiskProfileRepository : IRiskProfileRepository
{
    private static readonly List<RiskProfile> _db;

    static RiskProfileRepository()
    {
        _db = new(capacity: 100);
    }

    public void Create(RiskProfile entity)
    {
        _db.Add(entity);
        Console.WriteLine($"AFTER CREATE {_db.Count}");
    }

    public RiskProfile Get(string name)
    {
        return _db.Single(x => x.RiskName == name);
    }

    public void Update(string name, RiskProfile riskProfile)
    {
        RiskProfile existingRiskProfile = Get(name);
        Console.WriteLine($"BEFORE UPDATE {existingRiskProfile.RiskName}");
        if (existingRiskProfile != null)
        {
            Console.WriteLine($"UPDATE {existingRiskProfile.RiskName}");

            existingRiskProfile.RiskName = riskProfile.RiskName;
            existingRiskProfile.Description = riskProfile.Description;
            existingRiskProfile.BusinessProcess = riskProfile.BusinessProcess;
            existingRiskProfile.OccurreceProbability = riskProfile.OccurreceProbability;
            existingRiskProfile.PotentialBusinessImpact = riskProfile.PotentialBusinessImpact;

            Console.WriteLine($"AFTER UPDATE {existingRiskProfile.RiskName}");
        }
    }

    public void Delete(string name)
    {
        RiskProfile existingRiskProfile = _db.Single(x => x.RiskName == name);
        if (existingRiskProfile != null)
        {
            Console.WriteLine($"DELETE {existingRiskProfile.RiskName}");
            _db.Remove(existingRiskProfile);
        }
    }
}