using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.DataAccess.Models
{
    public class Parametros: BaseEntity<long>
    {
       
  
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public string? Desripcion { get; set; }
        public string? Valor { get; set; }
        public long? IdPadre { get; set; }
        public Parametros? ParametroPadre { get; set; }
        public List<Parametros>? ParametrosHijo { get; set; }
 
 
    }
}
