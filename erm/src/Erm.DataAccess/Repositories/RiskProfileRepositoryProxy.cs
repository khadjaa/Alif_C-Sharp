using System.Text.Json;

using StackExchange.Redis;

namespace Erm.DataAccess;

public sealed class RiskProfileRepositoryProxy : IRiskProfileRepository
{
    private readonly RiskProfileRepository _originalRepository;
    private const string RedisHost= "127.0.0.1:6379";
    private readonly IDatabase _redisDb;

    public RiskProfileRepositoryProxy(RiskProfileRepository originalRepository) 
    {
        _originalRepository = originalRepository;

        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(RedisHost);
        _redisDb = connectionMultiplexer.GetDatabase();
    }
 
    public Task CreateAsync(RiskProfile entity, CancellationToken token = default)
    {
        return _originalRepository.CreateAsync(entity, token);
    }

    public Task DeleteAsync(string name, CancellationToken token = default)
    {
        return _originalRepository.DeleteAsync(name, token);
    }

    public async Task<RiskProfile> GetAsync(string name, CancellationToken token = default)
    {
        RedisValue redisValue = await _redisDb.StringGetAsync(name);
        if (redisValue.IsNullOrEmpty)
        { 
            RiskProfile riskProfileFromDb = await _originalRepository.GetAsync(name, token);
            string redisRiskProfileJson = JsonSerializer.Serialize(riskProfileFromDb);

            await _redisDb.StringSetAsync(name, redisRiskProfileJson);
            Console.WriteLine("from sql");
            return riskProfileFromDb;
        }

        string redisProfileJsonStr = redisValue.ToString();

        RiskProfile riskProfile = JsonSerializer.Deserialize<RiskProfile>(redisProfileJsonStr)
            ?? throw new InvalidOperationException("Failed to deserialize RiskProfile from Redis");
        Console.WriteLine("from redis");
        return riskProfile;
    }

    public Task<IEnumerable<RiskProfile>> GetAllAsync(string query, CancellationToken token = default)
    {
        return _originalRepository.GetAllAsync(query, token);
    }

    public Task UpdateAsync(string name, RiskProfile riskProfile, CancellationToken token = default)
    {
       return _originalRepository.UpdateAsync(name, riskProfile, token);
    }
}