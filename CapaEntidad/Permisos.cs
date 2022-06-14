using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
public class Permisos
    {
        public int IdPermiso { get; set; }
        public Rol  oRol { get; set; }
        public string NombreMenu { get; set; }
        public string FechaCreacion { get; set; }
    }
}
