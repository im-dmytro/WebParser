using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParser.Migrations
{
    /// <inheritdoc />
    public partial class EditedTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartsGroups_ComplectationId",
                table: "PartsGroups");

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_ComplectationId",
                table: "PartsGroups",
                column: "ComplectationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartsGroups_ComplectationId",
                table: "PartsGroups");

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_ComplectationId",
                table: "PartsGroups",
                column: "ComplectationId",
                unique: true);
        }
    }
}
