namespace Erm.DataAccess;

public interface IRiskProfileRepository
{
    public RiskProfile Get(string name);
    public void Create(RiskProfile entity);
    void Update(string name, RiskProfile riskProfile);
    void Delete(string name);
}