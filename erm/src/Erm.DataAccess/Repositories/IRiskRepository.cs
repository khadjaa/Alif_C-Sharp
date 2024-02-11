namespace Erm.DataAccess;

public interface IRiskRepository
{
    public Risk Get(string name);
    public void Create(Risk entity);
    void Update(string name, Risk risk);
    void Delete(string name);
}