namespace Proyecto.DTOs
{
    public class InsertarCasaDTO
    {
     
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Medidas { get; set; } = null!;
        public string NroCasa { get; set; } = null!;
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        //public string Estadocasa { get; set; } = null!;
        //public string StatusFl { get; set; } = null!;
    }

    public class ActualizarCasaDTO : InsertarCasaDTO
    {
        public string Estadocasa { get; set; } = null!;
        public string StatusFl { get; set; } = null!;
    }

}
