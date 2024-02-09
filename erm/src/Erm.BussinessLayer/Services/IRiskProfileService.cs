
using Erm.DataAccess;

namespace Erm.BussinessLayer;

    public interface IRiskProfileService
    {
        public RiskProfile Get(string riskProfileName);
        void Create(RiskProfileInfo riskProfileInfo);
        void Update(string name, RiskProfileInfo riskProfileInfo);
        void Delete(string riskProfileName);
    }


