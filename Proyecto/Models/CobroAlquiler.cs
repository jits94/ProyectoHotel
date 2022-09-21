using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class CobroAlquiler
    {
        public int Id { get; set; }
        public int? Idalquilar { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoPago { get; set; } = null!;
        public decimal Multas { get; set; }
        public DateTime ProximoPago { get; set; }
        public string Estado { get; set; } = null!;

        public virtual AlquilerCasa? IdalquilarNavigation { get; set; }
    }
}
