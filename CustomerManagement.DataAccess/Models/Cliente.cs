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

        [Required(ErrorMessage = "El número de cuenta es obligatorio")]
        public required string NumeroCuenta { get; set; }

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
        public required Parametros EstadoCivil { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public required string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El tipo de cliente es obligatorio")]
        public long TipoClienteId { get; set; }

        [ForeignKey("TipoClienteId")]
        public required Parametros TipoCliente { get; set; }

        [Required(ErrorMessage = "La profesión u ocupación es obligatoria")]
        public required string ProfesionOcupacion { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public long GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public required Parametros Genero { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        public required string Nacionalidad { get; set; }
    }
}
