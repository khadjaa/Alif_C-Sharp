namespace Erm.DataAccess;

public interface IRiskProfileRepository
{
    public Task<RiskProfile> GetAsync(string name, CancellationToken token = default);
    public Task<IEnumerable<RiskProfile>> GetAllAsync(string query, CancellationToken token = default);
    public Task CreateAsync(RiskProfile entity, CancellationToken token = default);
    Task UpdateAsync(string name, RiskProfile riskProfile, CancellationToken token = default);
    Task DeleteAsync(string name, CancellationToken token = default);
}