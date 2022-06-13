using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherFin.Migrations
{
    public partial class CreateWeatherSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherModels",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfMeasurement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    weatherDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherModels", x => x.WeatherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherModels");
        }
    }
}
