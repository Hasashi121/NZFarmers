using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class FixedRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Users_UserID",
                table: "Farmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_UserID",
                table: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "FarmerLocations");

            migrationBuilder.DropTable(
                name: "OrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_UserID",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Farmers",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "FarmerID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "PaymentDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "PaymentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Farmers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Farmers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Farmers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Farmers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Farmers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmerMarketsEventID",
                table: "FarmerMarketParticipations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "DeliveryTrackings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "FarmerMarkets",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerMarkets", x => x.EventID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmerID",
                table: "Users",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_UserID1",
                table: "PaymentDetails",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID1",
                table: "Orders",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UserID",
                table: "Farmers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerMarketParticipations_FarmerMarketsEventID",
                table: "FarmerMarketParticipations",
                column: "FarmerMarketsEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerMarketParticipations_FarmerMarkets_FarmerMarketsEventID",
                table: "FarmerMarketParticipations",
                column: "FarmerMarketsEventID",
                principalTable: "FarmerMarkets",
                principalColumn: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_AspNetUsers_UserID",
                table: "Farmers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentID",
                table: "Orders",
                column: "PaymentID",
                principalTable: "PaymentDetails",
                principalColumn: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID1",
                table: "Orders",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_AspNetUsers_UserID",
                table: "PaymentDetails",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_UserID1",
                table: "PaymentDetails",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Farmers_FarmerID",
                table: "Users",
                column: "FarmerID",
                principalTable: "Farmers",
                principalColumn: "FarmerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerMarketParticipations_FarmerMarkets_FarmerMarketsEventID",
                table: "FarmerMarketParticipations");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_AspNetUsers_UserID",
                table: "Farmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_AspNetUsers_UserID",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_UserID1",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Farmers_FarmerID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FarmerMarkets");

            migrationBuilder.DropIndex(
                name: "IX_Users_FarmerID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_UserID1",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_UserID",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_FarmerMarketParticipations_FarmerMarketsEventID",
                table: "FarmerMarketParticipations");

            migrationBuilder.DropColumn(
                name: "FarmerID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmerMarketsEventID",
                table: "FarmerMarketParticipations");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Farmers",
                newName: "ContactNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PaymentDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "PaymentDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Farmers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DeliveryTrackings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "FarmerLocations",
                columns: table => new
                {
                    FarmerLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FarmersID = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerLocations", x => x.FarmerLocationID);
                    table.ForeignKey(
                        name: "FK_FarmerLocations_Farmers_FarmerID",
                        column: x => x.FarmerID,
                        principalTable: "Farmers",
                        principalColumn: "FarmerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPayments",
                columns: table => new
                {
                    OrderPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayments", x => x.OrderPaymentID);
                    table.ForeignKey(
                        name: "FK_OrderPayments_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPayments_PaymentDetails_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "PaymentDetails",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UserID",
                table: "Farmers",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FarmerLocations_FarmerID",
                table: "FarmerLocations",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_OrderID",
                table: "OrderPayments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPayments_PaymentID",
                table: "OrderPayments",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Users_UserID",
                table: "Farmers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_UserID",
                table: "PaymentDetails",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
