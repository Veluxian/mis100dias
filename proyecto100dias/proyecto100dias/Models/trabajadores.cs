using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using proyecto100dias.validaciones;
namespace proyecto100dias.Models
{
    public class trabajadores
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_trabajador")]
        public long id {get;set;}  
        public string? primer_nombre { get;set;}
        [AllowNull]
        public string? segundo_nombre { get;set;}
        public string? primer_apellido { get;set;}
        public string? segundo_apellido { get;set;}
        
        public int? rut_trabajador { get;set;}
        [validaciones.mayorDeEdad]
        public DateOnly? fecha_nacimiento { get;set;}
    }
}
