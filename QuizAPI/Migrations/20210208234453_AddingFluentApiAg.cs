using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class AddingFluentApiAg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers",
                column: "MathQuizId",
                principalTable: "MathQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers",
                column: "MathQuizId",
                principalTable: "MathQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
