using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class AddMathQuizAndNumberTableAginAndAgainas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MathQuizzes",
                table: "MathQuizzes");

            migrationBuilder.RenameTable(
                name: "Numbers",
                newName: "Number");

            migrationBuilder.RenameTable(
                name: "MathQuizzes",
                newName: "MathQuizze");

            migrationBuilder.RenameIndex(
                name: "IX_Numbers_MathQuizId",
                table: "Number",
                newName: "IX_Number_MathQuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Number",
                table: "Number",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_MathQuizze_MathQuizId",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Number",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MathQuizze",
                table: "MathQuizze");

            migrationBuilder.RenameTable(
                name: "Number",
                newName: "Numbers");

            migrationBuilder.RenameTable(
                name: "MathQuizze",
                newName: "MathQuizzes");

            migrationBuilder.RenameIndex(
                name: "IX_Number_MathQuizId",
                table: "Numbers",
                newName: "IX_Numbers_MathQuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MathQuizzes",
                table: "MathQuizzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers",
                column: "MathQuizId",
                principalTable: "MathQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
