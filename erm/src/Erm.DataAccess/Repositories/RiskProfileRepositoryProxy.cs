using System.Text.Json;

using Microsoft.Extensions.Caching.Distributed;

namespace Erm.DataAccess;

public sealed class RiskProfileRepositoryProxy(
    IDistributedCache distributedCache,
    RiskProfileRepository originalRepository)
    : IRiskProfileRepository
{
    private readonly IDistributedCache _db = distributedCache;

    public Task CreateAsync(RiskProfile entity, CancellationToken token = default)
    {
        return originalRepository.CreateAsync(entity, token);
    }

    public Task DeleteAsync(string name, CancellationToken token = default)
    {
        return originalRepository.DeleteAsync(name, token);
    }

    public async Task<RiskProfile> GetAsync(string name, CancellationToken token = default)
    {
        string? redisValue = await _db.GetStringAsync(name, token);
        if (string.IsNullOrEmpty(redisValue))
        {
            RiskProfile riskProfileFromDb = await originalRepository.GetAsync(name, token);
            string redisRiskProfileJson = JsonSerializer.Serialize(riskProfileFromDb);

            await _db.SetStringAsync(name, redisRiskProfileJson, token);
            Console.WriteLine("from sql");
            return riskProfileFromDb;
        }

        string redisProfileJsonStr = redisValue;

        RiskProfile riskProfile = JsonSerializer.Deserialize<RiskProfile>(redisProfileJsonStr)
                                  ?? throw new InvalidOperationException(
                                      "Failed to deserialize RiskProfile from Redis");
        Console.WriteLine("from redis");
        return riskProfile;
    }

    public Task<IEnumerable<RiskProfile>> GetAllAsync(string query, CancellationToken token = default)
    {
        return originalRepository.GetAllAsync(query, token);
    }

    public Task UpdateAsync(string name, RiskProfile riskProfile, CancellationToken token = default)
    {
        return originalRepository.UpdateAsync(name, riskProfile, token);
    }
}