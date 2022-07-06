using System;
using System.Threading.Tasks;
using PontoMaisDomain.Companies.Entities;

namespace PontoMaisDomain.Companies.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Company Get(Guid id);
    }
}
