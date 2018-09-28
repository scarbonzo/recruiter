using Microsoft.EntityFrameworkCore.Migrations;

namespace recruiter.api.Migrations
{
    public partial class AddReviewNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Reviews");
        }
    }
}
