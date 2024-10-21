using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiesDocker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManualChange",
                table: "Vehicles",
                type: "varchar(40)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManualChange",
                table: "Vehicles");
        }
    }
}
