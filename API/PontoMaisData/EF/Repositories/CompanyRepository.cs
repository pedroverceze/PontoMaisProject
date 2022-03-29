using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.Companies.Entities;
using PontoMaisDomain.Companies.Repositories;

namespace PontoMaisInfra.EF.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(Context context) : base(context)
        {  }

        public async Task Add(Company company)
        {
            await _dbSet.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> Get(Guid id)
        {
            return Filter(id)
                .First();
        }

        private IQueryable<Company> Filter(Guid id)
        {
            return _dbSet.Where(c => c.Id.Equals(id));
        }
    }
}
