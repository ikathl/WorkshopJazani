using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Mcs.Persistances
{
    public class AgreementRepository : CrudRepository<Agreement, int>, IAgreementRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AgreementRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Agreement?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Agreement>()
               .AsQueryable()
               .Include(t => t.AgreementType)
               .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
