using PontoMaisDomain.Companies.Entities;

namespace PontoMaisDomain.Companies.Services
{
    public interface ICompanyService
    {
        public Task Add(Company company);
        public Task<Company> Get(Guid id);
    }
}