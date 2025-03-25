using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class LinkedIdentityToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentDetailPaymentID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentDetailPaymentID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentDetailPaymentID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "PaymentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PaymentDetailPaymentID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentDetailPaymentID",
                table: "Orders",
                column: "PaymentDetailPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentDetailPaymentID",
                table: "Orders",
                column: "PaymentDetailPaymentID",
                principalTable: "PaymentDetails",
                principalColumn: "PaymentID");
        }
    }
}
