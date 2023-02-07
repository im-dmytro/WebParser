using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParser.Migrations
{
    /// <inheritdoc />
    public partial class AddedCodeTOGroupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "PartsSubGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "PartsGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PartsSubGroups_Code",
                table: "PartsSubGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_Code",
                table: "PartsGroups",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartsSubGroups_Code",
                table: "PartsSubGroups");

            migrationBuilder.DropIndex(
                name: "IX_PartsGroups_Code",
                table: "PartsGroups");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PartsSubGroups");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PartsGroups");
        }
    }
}
