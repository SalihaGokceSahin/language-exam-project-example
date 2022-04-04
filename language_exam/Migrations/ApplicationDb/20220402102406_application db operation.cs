using Microsoft.EntityFrameworkCore.Migrations;

namespace language_exam.Migrations.ApplicationDb
{
    public partial class applicationdboperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    outerHtml_href_for_link = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    context = table.Column<string>(nullable: true),
                    creator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
