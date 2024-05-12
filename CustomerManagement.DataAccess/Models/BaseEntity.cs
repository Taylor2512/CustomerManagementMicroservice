using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.DataAccess.Models
{
    public class BaseEntity: IEntity
    {
        public bool Activo { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public required string UsuarioCreacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
    }

    public class BaseEntity<T> : BaseEntity
        where T : struct
    {
        [Key]
        public T Id { get; set; }
    }
    public interface IEntity
    {
        public bool Activo { get; set; }

    }
}
