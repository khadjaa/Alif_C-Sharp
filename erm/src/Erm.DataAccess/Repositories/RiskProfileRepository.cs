
using Microsoft.EntityFrameworkCore;

namespace Erm.DataAccess;

public sealed class RiskProfileRepository : IRiskProfileRepository
{
    private readonly ErmDbContext _db = new();

    public async Task CreateAsync(RiskProfile entity, CancellationToken token = default)
    {
        await _db.RiskProfiles.AddAsync(entity, token);
        await _db.SaveChangesAsync(token);
    }

    public Task<RiskProfile> GetAsync(string name, CancellationToken token = default)
    {
       return _db.RiskProfiles.AsNoTracking().SingleAsync(x => x.RiskName.Equals(name), token);
    }

    public async Task UpdateAsync(string name, RiskProfile riskProfile, CancellationToken token = default)
    {
        RiskProfile riskProfileToUpdate =  await _db.RiskProfiles.SingleAsync(x => x.RiskName == name, token);
        
        riskProfileToUpdate.RiskName = riskProfile.RiskName;
        riskProfileToUpdate.Description = riskProfile.Description;
        riskProfileToUpdate.BusinessProcess = riskProfile.BusinessProcess;
        riskProfileToUpdate.OccurreceProbability = riskProfile.OccurreceProbability;
        riskProfileToUpdate.PotentialBusinessImpact = riskProfile.PotentialBusinessImpact;

        await _db.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(string name, CancellationToken token = default)
    {
        await _db.RiskProfiles.Where(x => x.RiskName.Equals(name)).ExecuteDeleteAsync(token);
        await _db.SaveChangesAsync(token);
    }

    public async Task<IEnumerable<RiskProfile>> GetAllAsync(string query, CancellationToken token = default)
    {
        return await _db.RiskProfiles
            .AsNoTracking()
            .Include(i => i.BusinessProcess)
            .Where(x => x.RiskName.Contains(query) || x.Description.Contains(query))
            .ToArrayAsync(token);
    }
}