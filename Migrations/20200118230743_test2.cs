using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyTogether.API.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    GradeNumber = table.Column<int>(nullable: false),
                    GradePercent = table.Column<double>(nullable: false),
                    DateDone = table.Column<DateTime>(nullable: false),
                    QuizNumber = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
