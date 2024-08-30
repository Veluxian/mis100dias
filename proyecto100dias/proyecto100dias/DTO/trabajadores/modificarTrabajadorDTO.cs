using proyecto100dias.validaciones;
using System.ComponentModel.DataAnnotations;

namespace proyecto100dias.DTO.trabajadores
{
    public class modificarTrabajadorDTO
    {
        [Required]
        public string? primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        [Required]
        public string? primerApellido { get; set; }
        [Required]
        public string? segundoApellido { get; set; }
        [mayorDeEdad, Required]
        public DateOnly? fechaNacimiento { get; set; }
    }
}
