using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class AddingFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers");

            migrationBuilder.AlterColumn<int>(
                name: "MathQuizId",
                table: "Numbers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers",
                column: "MathQuizId",
                principalTable: "MathQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_MathQuizzes_MathQuizId",
                table: "Numbers");

            migrationBuilder.AlterColumn<int>(
                name: "MathQuizId",
                table: "Numbers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
