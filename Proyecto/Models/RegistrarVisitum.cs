using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class RegistrarVisitum
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreVisita { get; set; } = null!;
        public string? PlacaVehiculo { get; set; }
        public int? CantidadPersonas { get; set; }
        public string Carnet { get; set; } = null!;

        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
