using System.ComponentModel.DataAnnotations;

namespace proyecto100dias.validaciones
{
    public class mayorDeEdad : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("La fecha de nacimiento es requerida");
            }
            DateOnly fechaNacimiento = (DateOnly)value;
            int edad = DateOnly.FromDateTime(DateTime.Now).Year - fechaNacimiento.Year;
            if(fechaNacimiento > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("No puede ser del futuro");
            }
            if(edad < 18)
            {
                return new ValidationResult("debe ser mayor de 18");
            }
            return ValidationResult.Success;
        }
    }
}
