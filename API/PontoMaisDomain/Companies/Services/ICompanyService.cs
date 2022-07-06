using System;
using System.Threading.Tasks;
using PontoMaisDomain.Companies.Entities;

namespace PontoMaisDomain.Companies.Services
{
    public interface ICompanyService
    {
        public Task Add(Company company);
        public Company Get(Guid id);
    }
}