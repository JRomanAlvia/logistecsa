using System.ComponentModel.DataAnnotations;

namespace Logistecsa.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public string? Rol { get; set; }
    }
}
