using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistecsa.Domain.Entities
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        [ForeignKey(nameof(ProjectData))]
        public int ProyectoId { get; set; }
        public virtual Project? ProjectData { get; set; }
    }
}
