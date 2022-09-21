using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Persona
    {
        public Persona()
        {
            AlquilerCasas = new HashSet<AlquilerCasa>();
            RegistrarVisita = new HashSet<RegistrarVisitum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Carnet { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public int? MiembrosFamilia { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<AlquilerCasa> AlquilerCasas { get; set; }
        public virtual ICollection<RegistrarVisitum> RegistrarVisita { get; set; }
    }
}
