using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigma.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    EngineCapacity = table.Column<float>(nullable: false),
                    TypeOfTransmition = table.Column<string>(nullable: true),
                    AdditionalCharacteristics = table.Column<string>(nullable: true),

                    PriceRatio = table.Column<float>(nullable: false),
                    NameOfType = table.Column<string>(nullable: true),
                    NumberOfType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });
            migrationBuilder.CreateTable(
               name: "TypeCar",
               columns: table => new
               {
                   NumberOfType = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   NameOfType = table.Column<string>(nullable: true),
                   DefaultPrice = table.Column<float>(nullable: false),
                  
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Car", x => x.NumberOfType);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
            migrationBuilder.DropTable(
               name: "TypeCar");
        }
    }
}
