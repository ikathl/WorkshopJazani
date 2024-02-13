using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistances;

namespace Jazani.Infrastructure.Mcs.Persistances
{
    public class AgreementTypeRepository : CrudRepository<AgreementType, int>, IAgreementTypeRepository
    {
        public AgreementTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
