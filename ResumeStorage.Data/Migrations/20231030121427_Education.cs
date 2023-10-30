using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeStorage.Data.Migrations
{
    public partial class Education : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicProfileId = table.Column<int>(type: "int", nullable: false),
                    NameOfSchool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_BasicProfiles_BasicProfileId",
                        column: x => x.BasicProfileId,
                        principalTable: "BasicProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_BasicProfileId",
                table: "Educations",
                column: "BasicProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");
        }
    }
}
