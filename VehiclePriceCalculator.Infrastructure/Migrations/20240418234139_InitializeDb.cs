using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehiclePriceCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePriceTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiclePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BasicFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpecialFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssociationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StorageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePriceTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePriceTransaction_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "VehicleTypeName" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 4, 18, 19, 41, 38, 356, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 4, 18, 19, 41, 38, 356, DateTimeKind.Local).AddTicks(9401), "System", "Common" },
                    { 2, "System", new DateTime(2024, 4, 18, 19, 41, 38, 356, DateTimeKind.Local).AddTicks(9418), new DateTime(2024, 4, 18, 19, 41, 38, 356, DateTimeKind.Local).AddTicks(9431), "System", "Luxury" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceTransaction_VehicleTypeId",
                table: "VehiclePriceTransaction",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclePriceTransaction");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
