using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyTogether.API.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerNumber = table.Column<int>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    CorectAnswer = table.Column<string>(nullable: true),
                    StudentAnswer = table.Column<string>(nullable: true),
                    QuizNumber = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNumber = table.Column<int>(nullable: false),
                    QuestionMain = table.Column<string>(nullable: true),
                    CorectAnswer = table.Column<string>(nullable: true),
                    IncorectFirst = table.Column<string>(nullable: true),
                    IncorectSecond = table.Column<string>(nullable: true),
                    IncorectThird = table.Column<string>(nullable: true),
                    Hint = table.Column<string>(nullable: true),
                    QuizNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizNumber = table.Column<int>(nullable: false),
                    QuizName = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    StudentNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNumber = table.Column<int>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    TotaltQuizzes = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
