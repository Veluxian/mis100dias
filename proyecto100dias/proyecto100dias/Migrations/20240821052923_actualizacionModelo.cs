using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto100dias.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaNacimiento",
                table: "trabajadores");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "trabajadores",
                newName: "id_trabajador");

            migrationBuilder.RenameColumn(
                name: "segundoNombre",
                table: "trabajadores",
                newName: "segundo_nombre");

            migrationBuilder.RenameColumn(
                name: "segundoApellido",
                table: "trabajadores",
                newName: "segundo_apellido");

            migrationBuilder.RenameColumn(
                name: "rutTrabajador",
                table: "trabajadores",
                newName: "rut_trabajador");

            migrationBuilder.RenameColumn(
                name: "primerNombre",
                table: "trabajadores",
                newName: "primer_nombre");

            migrationBuilder.RenameColumn(
                name: "primerApellido",
                table: "trabajadores",
                newName: "primer_apellido");

            migrationBuilder.AddColumn<DateOnly>(
                name: "fecha_nacimiento",
                table: "trabajadores",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_nacimiento",
                table: "trabajadores");

            migrationBuilder.RenameColumn(
                name: "id_trabajador",
                table: "trabajadores",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "segundo_nombre",
                table: "trabajadores",
                newName: "segundoNombre");

            migrationBuilder.RenameColumn(
                name: "segundo_apellido",
                table: "trabajadores",
                newName: "segundoApellido");

            migrationBuilder.RenameColumn(
                name: "rut_trabajador",
                table: "trabajadores",
                newName: "rutTrabajador");

            migrationBuilder.RenameColumn(
                name: "primer_nombre",
                table: "trabajadores",
                newName: "primerNombre");

            migrationBuilder.RenameColumn(
                name: "primer_apellido",
                table: "trabajadores",
                newName: "primerApellido");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaNacimiento",
                table: "trabajadores",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
