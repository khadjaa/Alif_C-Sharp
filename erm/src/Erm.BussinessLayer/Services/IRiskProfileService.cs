
using Erm.DataAccess;

namespace Erm.BussinessLayer;

public interface IRiskProfileService
{
    public RiskProfileInfo Get(string riskProfileName);
    IEnumerable<RiskProfileInfo> Query(string query);
    void Create(RiskProfileInfo riskProfileInfo);
    void Update(string riskProfileName, RiskProfileInfo riskProfileInfo);
    void Delete(string riskProfileName);
    double CalculateRisk(string riskProfileName);
}