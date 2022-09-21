using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Carnet { get; set; } = null!;
        public int? IdRol { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
