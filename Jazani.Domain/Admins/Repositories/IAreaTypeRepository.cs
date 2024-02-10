using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IAreaTypeRepository
    {
        Task<IReadOnlyList<AreaType>> FindAllAsync();
        Task<AreaType?> FindByIdAsync(int id);
        Task<AreaType>SaveAsync(AreaType areaType);

    }
}
