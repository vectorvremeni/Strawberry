using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Data.Migrations
{
    public partial class presentsuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "PR",
                table: "Presents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "PR",
                table: "Presents");
        }
    }
}
