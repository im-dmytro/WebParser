using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParser.Migrations
{
    /// <inheritdoc />
    public partial class FixedComplectationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complectation_Models_ModelId",
                table: "Complectation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complectation",
                table: "Complectation");

            migrationBuilder.RenameTable(
                name: "Complectation",
                newName: "Complectations");

            migrationBuilder.RenameIndex(
                name: "IX_Complectation_ModelId",
                table: "Complectations",
                newName: "IX_Complectations_ModelId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Complectations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Complectations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complectations",
                table: "Complectations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Complectations_Name",
                table: "Complectations",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complectations_Models_ModelId",
                table: "Complectations",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complectations_Models_ModelId",
                table: "Complectations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complectations",
                table: "Complectations");

            migrationBuilder.DropIndex(
                name: "IX_Complectations_Name",
                table: "Complectations");

            migrationBuilder.RenameTable(
                name: "Complectations",
                newName: "Complectation");

            migrationBuilder.RenameIndex(
                name: "IX_Complectations_ModelId",
                table: "Complectation",
                newName: "IX_Complectation_ModelId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Complectation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Complectation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complectation",
                table: "Complectation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complectation_Models_ModelId",
                table: "Complectation",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }
    }
}
