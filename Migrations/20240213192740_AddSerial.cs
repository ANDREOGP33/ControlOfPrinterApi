using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlOfPrinterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Printers",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Printers");
        }
    }
}
