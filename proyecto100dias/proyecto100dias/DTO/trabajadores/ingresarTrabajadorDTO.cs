using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using proyecto100dias.validaciones;
namespace proyecto100dias.DTO.trabajadores
{
    public class ingresarTrabajadorDTO
    {
        [Required]
        public string primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        [Required]
        public string primerApellido { get; set; }
        [Required]
        public string segundoApellido { get; set; }
        [Key, Required]
        public int rutTrabajador { get; set; }
        [mayorDeEdad, Required]
        public DateOnly fechaNacimiento { get; set; }
    }
}
