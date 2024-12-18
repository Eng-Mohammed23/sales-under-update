using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.web.Migrations
{
    /// <inheritdoc />
    public partial class AddTheSourcePriceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TheSourcePrice",
                table: "Items",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheSourcePrice",
                table: "Items");
        }
    }
}
