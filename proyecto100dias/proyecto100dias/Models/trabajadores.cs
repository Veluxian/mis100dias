namespace proyecto100dias.Models
{
    public class trabajadores
    {
        public long id {get;set;}  
        public string? primerNombre { get;set;}
        public string? segundoNombre { get;set;}
        public string? primerApellido { get;set;}
        public string? segundoApellido { get;set;}
        public int? rutTrabajador { get;set;}
        public DateTime? fechaNacimiento { get;set;}
    }
}
