namespace Proyecto.DTOs
{
    public class RolDTO
    {
        public int Id { get; set; }
        public string Nombrecargo { get; set; } = null!;
        public int? IdPermisos { get; set; }
        public string Area { get; set; } = null!;

    }
}
