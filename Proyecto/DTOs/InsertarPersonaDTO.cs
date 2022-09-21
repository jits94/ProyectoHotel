using System.ComponentModel.DataAnnotations;

namespace Proyecto.DTOs
{
    public class InsertarPersonaDTO
    {

       
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Carnet { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public int? MiembrosFamilia { get; set; }
        public string Estado { get; set; } = null!;
    }
}
