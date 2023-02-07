using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParser.Migrations
{
    /// <inheritdoc />
    public partial class EditedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartsSubGroups_Code",
                table: "PartsSubGroups");

            migrationBuilder.DropIndex(
                name: "IX_PartsSubGroups_Name",
                table: "PartsSubGroups");

            migrationBuilder.DropIndex(
                name: "IX_PartsGroups_Code",
                table: "PartsGroups");

            migrationBuilder.DropIndex(
                name: "IX_PartsGroups_Name",
                table: "PartsGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsSubGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsSubGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PartsGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PartsSubGroups_Code",
                table: "PartsSubGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsSubGroups_Name",
                table: "PartsSubGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_Code",
                table: "PartsGroups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_Name",
                table: "PartsGroups",
                column: "Name",
                unique: true);
        }
    }
}
