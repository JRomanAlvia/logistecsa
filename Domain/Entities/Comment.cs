using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistecsa.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(nameof(UserData))]
        public int UsuarioId { get; set; }
        public virtual User? UserData { get; set; }
        [ForeignKey(nameof(TaskData))]
        public int TareaId { get; set; }
        public virtual Tarea? TaskData { get; set; }
    }
    
}
