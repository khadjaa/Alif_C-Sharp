
using Microsoft.EntityFrameworkCore;

namespace Erm.DataAccess;

public sealed class RiskProfileRepository : IRiskProfileRepository
{
    private readonly ErmDbContext _db = new();

    public void Create(RiskProfile entity)
    {
        _db.RiskProfiles.Add(entity);
        _db.SaveChanges();
    }

    public RiskProfile Get(string name)
    {
        return _db.RiskProfiles.AsNoTracking().Single(x => x.RiskName == name);
    }

    public void Update(string name, RiskProfile riskProfile)
    {
        RiskProfile riskProfileToUpdate =  _db.RiskProfiles.Single(x => x.RiskName == name);
        
        riskProfileToUpdate.RiskName = riskProfile.RiskName;
        riskProfileToUpdate.Description = riskProfile.Description;
        riskProfileToUpdate.BusinessProcess = riskProfile.BusinessProcess;
        riskProfileToUpdate.OccurreceProbability = riskProfile.OccurreceProbability;
        riskProfileToUpdate.PotentialBusinessImpact = riskProfile.PotentialBusinessImpact;

        _db.SaveChanges();
    }

    public void Delete(string name)
    {
        _db.RiskProfiles.Where(x => x.RiskName.Equals(name)).ExecuteDelete();
        _db.SaveChanges();
    }

    public IEnumerable<RiskProfile> GetAll(string query)
    {
        return _db.RiskProfiles.AsNoTracking().Include(i => i.BusinessProcess).Where(x => x.RiskName.Contains(query) || x.Description.Contains(query));
    }
}