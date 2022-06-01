using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtensionEmpleado.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ext");

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "Ext",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "Ext");
        }
    }
}
