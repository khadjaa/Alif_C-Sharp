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
    }

    public RiskProfile Get(string name)
    {
        return _db.Single(x => x.RiskName == name);
    }

    public void Update(string name, RiskProfile riskProfile)
    {
        // RiskProfile existingRiskProfile = Get(name);
        // if (existingRiskProfile != null)
        // {
        //     existingRiskProfile.Name = riskProfile.Name;
        //     existingRiskProfile.Description = riskProfile.Description;
        //     existingRiskProfile.BusinessProcess = riskProfile.BusinessProcess;
        //     existingRiskProfile.OccurreceProbability = riskProfile.OccurreceProbability;
        //     existingRiskProfile.PotentialBusinessImpact = riskProfile.PotentialBusinessImpact;
        //     _dbContext.SaveChanges();
        // }
    }

    public void Delete(int riskProfileId)
    {
        // RiskProfile existingRiskProfile = _dbContext.RiskProfiles.FirstOrDefault(rp => rp.Id == riskProfileId);
        // if (existingRiskProfile != null)
        // {
        //     _dbContext.RiskProfiles.Remove(existingRiskProfile);
        //     _dbContext.SaveChanges();
        // }
    }
}