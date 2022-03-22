using Microsoft.EntityFrameworkCore;

namespace PontoMaisInfra.EF.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
    }
}
