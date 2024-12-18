using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.web.Migrations
{
    /// <inheritdoc />
    public partial class AddSortOfQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsDetails_Orders_OrderId",
                table: "ItemsDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ItemsDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SortOfQuantity1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortOfQuantity2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortOfQuantity3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsDetails_Orders_OrderId",
                table: "ItemsDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsDetails_Orders_OrderId",
                table: "ItemsDetails");

            migrationBuilder.DropColumn(
                name: "SortOfQuantity1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SortOfQuantity2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SortOfQuantity3",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ItemsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsDetails_Orders_OrderId",
                table: "ItemsDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
