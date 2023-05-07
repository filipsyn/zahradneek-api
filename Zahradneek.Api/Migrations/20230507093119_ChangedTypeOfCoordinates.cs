using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zahradneek.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTypeOfCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "coordinates",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "coordinates",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "coordinates",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<float>(
                name: "latitude",
                table: "coordinates",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
