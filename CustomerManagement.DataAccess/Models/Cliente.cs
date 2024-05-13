using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.DataAccess.Models
{
    public class Cliente : BaseEntity<Guid>
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public required string Apellido { get; set; }

         public   string? NumeroCuenta { get; set; }

        public decimal Saldo { get; set; } = 0M;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico no válido")]
        public required string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El estado civil es obligatorio")]
        public long EstadoCivilId { get; set; }

        [ForeignKey("EstadoCivilId")]
        public Parametros? EstadoCivil { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public required string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El tipo de cliente es obligatorio")]
        public long TipoClienteId { get; set; }

        public Parametros? TipoCliente { get; set; }

        public string? ProfesionOcupacion { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public long GeneroId { get; set; }

        public Parametros? Genero { get; set; }

        public string? Nacionalidad { get; set; }
    }
}
