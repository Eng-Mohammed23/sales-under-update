using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.web.Migrations
{
    /// <inheritdoc />
    public partial class DiscountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AfterDiscount",
                table: "Orders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Orders",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterDiscount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");
        }
    }
}
