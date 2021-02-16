using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class ChangingAndRemoving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_MathQuizze_MathQuizId",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MathQuizze",
                table: "MathQuizze");

            migrationBuilder.RenameTable(
                name: "MathQuizze",
                newName: "MathQuiz");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MathQuiz",
                table: "MathQuiz",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_MathQuiz_MathQuizId",
                table: "Number",
                column: "MathQuizId",
                principalTable: "MathQuiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_MathQuiz_MathQuizId",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MathQuiz",
                table: "MathQuiz");

            migrationBuilder.RenameTable(
                name: "MathQuiz",
                newName: "MathQuizze");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MathQuizze",
                table: "MathQuizze",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_MathQuizze_MathQuizId",
                table: "Number",
                column: "MathQuizId",
                principalTable: "MathQuizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
