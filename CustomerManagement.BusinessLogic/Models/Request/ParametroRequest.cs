using CustomerManagement.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BusinessLogic.Models.Request
{
    public record ParametroRequest
    {
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public string? Desripcion { get; set; }
        public string? Valor { get; set; }
        public long? IdPadre { get; set; }
        public ParametroRequest? ParametroPadre { get; set; }
        public List<ParametroRequest>? ParametrosHijo { get; set; }
    }
}
