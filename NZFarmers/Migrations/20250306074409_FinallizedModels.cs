using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class FinallizedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Orders",
                newName: "PaymentDetailPaymentID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders",
                newName: "IX_Orders_PaymentDetailPaymentID");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "DeliveryTrackings",
                newName: "LastUpdated");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Farmers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farmers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentDetailPaymentID",
                table: "Orders",
                column: "PaymentDetailPaymentID",
                principalTable: "PaymentDetails",
                principalColumn: "PaymentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentDetailPaymentID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentDetailPaymentID",
                table: "Orders",
                newName: "PaymentID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentDetailPaymentID",
                table: "Orders",
                newName: "IX_Orders_PaymentID");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "DeliveryTrackings",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Farmers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farmers",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentID",
                table: "Orders",
                column: "PaymentID",
                principalTable: "PaymentDetails",
                principalColumn: "PaymentID");
        }
    }
}
