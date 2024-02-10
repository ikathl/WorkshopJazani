using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.Areas
{
    public class AreaSmallDto
    {
        public int AreaTypeId { get; set; }
        public string Name { get; set; } = default!;//obligatorio que tenga un valor
        
    }
}
