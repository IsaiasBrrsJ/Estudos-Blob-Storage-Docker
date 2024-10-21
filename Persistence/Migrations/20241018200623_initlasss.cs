using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiesDocker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initlasss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Vehicles",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkPhoto",
                table: "Vehicles",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Name",
                table: "Vehicles",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LinkPhoto",
                table: "Vehicles");
        }
    }
}
