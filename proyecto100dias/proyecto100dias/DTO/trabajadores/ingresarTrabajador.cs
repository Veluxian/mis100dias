namespace proyecto100dias.DTO.trabajadores

{
    public class ingresarTrabajador
    {
        private static ingresarTrabajadorDTO ingresoADTO(Models.trabajadores trabajador) =>
            new ingresarTrabajadorDTO
            {
                primerNombre = trabajador.primer_nombre,
                segundoNombre = trabajador.segundo_nombre,
                primerApellido = trabajador.primer_apellido,
                segundoApellido = trabajador.segundo_apellido,
                rutTrabajador = trabajador.rut_trabajador,
                fechaNacimiento = trabajador.fecha_nacimiento
            };
    }
}
