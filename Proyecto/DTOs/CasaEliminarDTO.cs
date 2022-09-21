using System.ComponentModel.DataAnnotations;

namespace Proyecto.DTOs
{
    public class CasaEliminarDTO
    {
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Medidas { get; set; } = null!;
        public string NroCasa { get; set; } = null!;
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public string Estadocasa { get; set; } = null!;
        public string StatusFl { get; set; } = null!;
    }
}
