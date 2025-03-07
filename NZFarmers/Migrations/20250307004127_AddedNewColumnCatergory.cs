using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnCatergory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "FarmerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "FarmerProducts");
        }
    }
}
