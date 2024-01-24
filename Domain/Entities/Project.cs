using System.ComponentModel.DataAnnotations;

namespace Logistecsa.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
