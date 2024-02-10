using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Models
{
    public class AreaType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;//obligatorio que tenga un valor
        public string?  Description{ get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get;set; }

    }
}
