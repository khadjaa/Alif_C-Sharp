namespace Erm.DataAccess;

public interface IRiskProfileRepository
{
    public void Create(RiskProfile entity);
    public RiskProfile Get(string name);
    
    void Update(string name, RiskProfile riskProfile);
    void Delete(int riskProfileId);
}