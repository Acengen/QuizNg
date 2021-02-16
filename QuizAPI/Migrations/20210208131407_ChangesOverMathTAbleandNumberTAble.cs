using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class ChangesOverMathTAbleandNumberTAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    MathRandomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Number_Maths_MathRandomId",
                        column: x => x.MathRandomId,
                        principalTable: "Maths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Number_MathRandomId",
                table: "Number",
                column: "MathRandomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Number");
        }
    }
}
