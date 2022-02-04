using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationExample.Migrations
{
    public partial class initialcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "type_template",
                newName: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "type_template",
                newName: "TypeId");
        }
    }
}
