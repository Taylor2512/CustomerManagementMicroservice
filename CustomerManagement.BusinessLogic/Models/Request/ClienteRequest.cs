using System.ComponentModel.DataAnnotations;


namespace CustomerManagement.BusinessLogic.Models.Request
{
    public record ClienteRequest
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
        public long EstadoCivilId { get; set; }
        public required string NumeroIdentificacion { get; set; }
        public long TipoClienteId { get; set; }

        [Required(ErrorMessage = "La profesión u ocupación es obligatoria")]
        public required string ProfesionOcupacion { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public long GeneroId { get; set; }

         public   string? Nacionalidad { get; set; }

    }
}
