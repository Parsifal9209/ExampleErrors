using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationExample.Migrations
{
    public partial class initialcreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    organization_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.organization_id);
                });

            migrationBuilder.CreateTable(
                name: "type_template",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_template", x => new { x.TypeId, x.organization_id });
                    table.ForeignKey(
                        name: "FK_type_template_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organization",
                        principalColumn: "organization_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uuid", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    name_contract = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.CorrelationId);
                    table.ForeignKey(
                        name: "FK_contract_type_template_type_id_organization_id",
                        columns: x => new { x.type_id, x.organization_id },
                        principalTable: "type_template",
                        principalColumns: new[] { "TypeId", "organization_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contract_type_id_organization_id",
                table: "contract",
                columns: new[] { "type_id", "organization_id" });

            migrationBuilder.CreateIndex(
                name: "IX_type_template_organization_id",
                table: "type_template",
                column: "organization_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "type_template");

            migrationBuilder.DropTable(
                name: "organization");
        }
    }
}
