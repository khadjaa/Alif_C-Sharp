namespace Erm.DataAccess;

public sealed class RiskRepository : IRiskRepository
{
    private static readonly List<Risk> _db;

    static RiskRepository()
    {
        _db = new(capacity: 100);
    }

    public void Create(Risk entity)
    {
        _db.Add(entity);
        Console.WriteLine($"AFTER CREATE {_db.Count}");
    }

    public Risk Get(string name)
    {
        return _db.Single(x => x.Name == name);
    }

    public void Update(string name, Risk risk)
    {
        Risk existingRisk = Get(name);
        Console.WriteLine($"BEFORE UPDATE {existingRisk.Name}");
        if (existingRisk != null)
        {
            Console.WriteLine($"UPDATE {existingRisk.Name}");

            existingRisk.Name = risk.Name;
            existingRisk.Description = risk.Description;
            existingRisk.OccurrenceProbability = risk.OccurrenceProbability;
            existingRisk.PotentialBusinessImpact = risk.PotentialBusinessImpact;

            Console.WriteLine($"AFTER UPDATE {existingRisk.Name}");
        }
    }
    public void Delete(string name)
    {
        Risk existingRisk = _db.Single(x => x.Name == name);
        if (existingRisk != null)
        {
            Console.WriteLine($"DELETE {existingRisk.Name}");
            _db.Remove(existingRisk);
        }
    }
}