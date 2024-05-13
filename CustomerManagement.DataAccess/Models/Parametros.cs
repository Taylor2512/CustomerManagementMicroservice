using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.DataAccess.Models
{
    public class Parametros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esta línea indica que el valor de Id se genera automáticamente

        public long Id { get; set; }
        public required string Ccodigo { get; set; }
        public required string Nombre { get; set; }
        public string? Desripcion { get; set; }
        public string? Valor { get; set; }
        public long? IdPadre { get; set; }
        public Parametros? ParametroPadre { get; set; }
        public List<Parametros>? ParametrosHijo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public required string UsuarioCreacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
    }
}
