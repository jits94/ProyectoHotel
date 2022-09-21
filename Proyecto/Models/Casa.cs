using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public partial class Casa
    {
        public Casa()
        {
            AlquilerCasas = new HashSet<AlquilerCasa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Medidas { get; set; } = null!;
        public string NroCasa { get; set; } = null!;
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public string Estadocasa { get; set; } = null!;
        public string StatusFl { get; set; } = null!;

        public virtual ICollection<AlquilerCasa> AlquilerCasas { get; set; }
    }
}
