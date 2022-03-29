using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Token
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
