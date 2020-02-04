using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigma.Migrations
{
    public partial class IdentityCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityCode",
                table: "AspNetUsers");
        }
    }
}
