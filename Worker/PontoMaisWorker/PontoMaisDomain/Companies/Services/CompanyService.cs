using PontoMaisDomain.Companies.Entities;
using PontoMaisDomain.Companies.Repositories;

namespace PontoMaisDomain.Companies.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Add(Company company)
        {
            await _companyRepository.Add(company);
        }

        public async Task<Company> Get(Guid id)
        {
            return await _companyRepository.Get(id);
        }
    }
}
