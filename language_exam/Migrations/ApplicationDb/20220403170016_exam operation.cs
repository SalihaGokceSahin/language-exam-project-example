using Microsoft.EntityFrameworkCore.Migrations;

namespace language_exam.Migrations.ApplicationDb
{
    public partial class examoperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matchId = table.Column<int>(nullable: false),
                    creator = table.Column<string>(nullable: true),
                    question_1_text = table.Column<string>(nullable: true),
                    answer_1_a_text = table.Column<string>(nullable: true),
                    answer_1_b_text = table.Column<string>(nullable: true),
                    answer_1_c_text = table.Column<string>(nullable: true),
                    answer_1_d_text = table.Column<string>(nullable: true),
                    correct_1_answer = table.Column<string>(nullable: true),
                    question_2_text = table.Column<string>(nullable: true),
                    answer_2_a_text = table.Column<string>(nullable: true),
                    answer_2_b_text = table.Column<string>(nullable: true),
                    answer_2_c_text = table.Column<string>(nullable: true),
                    answer_2_d_text = table.Column<string>(nullable: true),
                    correct_2_answer = table.Column<string>(nullable: true),
                    question_3_text = table.Column<string>(nullable: true),
                    answer_3_a_text = table.Column<string>(nullable: true),
                    answer_3_b_text = table.Column<string>(nullable: true),
                    answer_3_c_text = table.Column<string>(nullable: true),
                    answer_3_d_text = table.Column<string>(nullable: true),
                    correct_3_answer = table.Column<string>(nullable: true),
                    question_4_text = table.Column<string>(nullable: true),
                    answer_4_a_text = table.Column<string>(nullable: true),
                    answer_4_b_text = table.Column<string>(nullable: true),
                    answer_4_c_text = table.Column<string>(nullable: true),
                    answer_4_d_text = table.Column<string>(nullable: true),
                    correct_4_answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Matches_matchId",
                        column: x => x.matchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_matchId",
                table: "Exams",
                column: "matchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
