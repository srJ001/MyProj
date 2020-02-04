using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigma.Migrations
{
    public partial class PhotoWay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoWay",
                table: "Car",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoWay",
                table: "Car");
        }
    }
}
