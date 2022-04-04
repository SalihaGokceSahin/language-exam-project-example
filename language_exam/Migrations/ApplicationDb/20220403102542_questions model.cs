using Microsoft.EntityFrameworkCore.Migrations;

namespace language_exam.Migrations.ApplicationDb
{
    public partial class questionsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matchId = table.Column<int>(nullable: false),
                    question_text = table.Column<string>(nullable: true),
                    answer_a_text = table.Column<string>(nullable: true),
                    answer_b_text = table.Column<string>(nullable: true),
                    answer_c_text = table.Column<string>(nullable: true),
                    answer_d_text = table.Column<string>(nullable: true),
                    correct_answer = table.Column<string>(nullable: true),
                    creator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Matches_matchId",
                        column: x => x.matchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_matchId",
                table: "Questions",
                column: "matchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
