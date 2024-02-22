
using Erm.DataAccess;

namespace Erm.BussinessLayer;

public interface IRiskProfileService
{
    Task<RiskProfileInfo> GetAsync(string riskProfileName, CancellationToken token = default);
    Task<IEnumerable<RiskProfileInfo>> QueryAsync(string query, CancellationToken token = default);
    Task CreateAsync(RiskProfileInfo riskProfileInfo, CancellationToken token = default);
    Task UpdateAsync(string riskProfileName, RiskProfileInfo riskProfileInfo, CancellationToken token = default);
    Task DeleteAsync(string riskProfileName, CancellationToken token = default);
    Task<double> CalculateRiskAsync(string riskProfileName);
}