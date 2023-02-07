using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebParser.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartsGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComplectationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsGroups_Complectations_ComplectationId",
                        column: x => x.ComplectationId,
                        principalTable: "Complectations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartsSubGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartsGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsSubGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsSubGroups_PartsGroups_PartsGroupId",
                        column: x => x.PartsGroupId,
                        principalTable: "PartsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    ReplacementCode = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartsSubGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_PartsSubGroups_PartsSubGroupId",
                        column: x => x.PartsSubGroupId,
                        principalTable: "PartsSubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Code",
                table: "Parts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartsSubGroupId",
                table: "Parts",
                column: "PartsSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_ComplectationId",
                table: "PartsGroups",
                column: "ComplectationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsGroups_Name",
                table: "PartsGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsSubGroups_Name",
                table: "PartsSubGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsSubGroups_PartsGroupId",
                table: "PartsSubGroups",
                column: "PartsGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PartsSubGroups");

            migrationBuilder.DropTable(
                name: "PartsGroups");
        }
    }
}
