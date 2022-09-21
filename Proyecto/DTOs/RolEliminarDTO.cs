using System.ComponentModel.DataAnnotations;

namespace Proyecto.DTOs
{
    public class RolEliminarDTO
    {
        [Required]
        public int Id { get; set; }
        public string Nombrecargo { get; set; } = null!;
        public int? IdPermisos { get; set; }
        public string Area { get; set; } = null!;
    }
}
