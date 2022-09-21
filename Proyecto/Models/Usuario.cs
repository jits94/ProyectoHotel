using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AlquilerCasas = new HashSet<AlquilerCasa>();
        }

        public int Id { get; set; }
        public int? IdEmpleado { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contra { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual Empleado? IdEmpleadoNavigation { get; set; }
        public virtual ICollection<AlquilerCasa> AlquilerCasas { get; set; }
    }
}
