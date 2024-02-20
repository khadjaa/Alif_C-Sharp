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
 
    public void Create(RiskProfile entity)
    {
        _originalRepository.Create(entity);
    }

    public void Delete(string name)
    {
        _originalRepository.Delete(name);
    }

    public RiskProfile Get(string name)
    {
        RedisValue redisValue = _redisDb.StringGet(name);
        if (redisValue.IsNullOrEmpty)
        { 
            RiskProfile riskProfileFromDb = _originalRepository.Get(name);
            string redisRiskProfileJson = JsonSerializer.Serialize(riskProfileFromDb);

            _redisDb.StringSet(name, redisRiskProfileJson);
            Console.WriteLine("from sql");
            return riskProfileFromDb;
        }

        string redisProfileJsonStr = redisValue.ToString();

        RiskProfile riskProfile = JsonSerializer.Deserialize<RiskProfile>(redisProfileJsonStr)
            ?? throw new InvalidOperationException("Failed to deserialize RiskProfile from Redis");
        Console.WriteLine("from redis");
        return riskProfile;
    }

    public IEnumerable<RiskProfile> GetAll(string query)
    {
        return _originalRepository.GetAll(query);
    }

    public void Update(string name, RiskProfile riskProfile)
    {
        _originalRepository.Update(name, riskProfile);
    }
}