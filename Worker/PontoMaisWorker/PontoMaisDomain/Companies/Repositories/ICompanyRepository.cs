using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.Companies.Entities;

namespace PontoMaisDomain.Companies.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Task<Company> Get(Guid id);
    }
}
