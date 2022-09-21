using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class AlquilerCasa
    {
        public AlquilerCasa()
        {
            CobroAlquilers = new HashSet<CobroAlquiler>();
        }

        public int Id { get; set; }
        public int IdCasa { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = null!;
        public int IdUsuario { get; set; }

        public virtual Casa IdCasaNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<CobroAlquiler> CobroAlquilers { get; set; }
    }
}
