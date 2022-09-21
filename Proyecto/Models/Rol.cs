using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombrecargo { get; set; } = null!;
        public int? IdPermisos { get; set; }
        public string Area { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
