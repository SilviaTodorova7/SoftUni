using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedOnColumnToHouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("1588d8d3-20bf-479c-af65-66ae6bcc60ca"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b475e659-1708-4938-ae0d-7ef01e31d202"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("bb6e7345-bdea-4e1b-b883-29502f39f21f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 25, 12, 43, 13, 796, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("466bed7c-b1f8-4692-9964-13d7cd864ed7"), "North London, UK (near the border)", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("3d2efb91-33ac-4135-162a-08dc4cb7d1a6"), "Big House Marina" },
                    { new Guid("d5877c54-2fdf-4241-a1da-989e04c4f5f6"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("efe1682d-e94e-46ea-a8c7-e755cb64fce0"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("466bed7c-b1f8-4692-9964-13d7cd864ed7"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("d5877c54-2fdf-4241-a1da-989e04c4f5f6"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("efe1682d-e94e-46ea-a8c7-e755cb64fce0"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Houses");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("1588d8d3-20bf-479c-af65-66ae6bcc60ca"), "North London, UK (near the border)", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("3d2efb91-33ac-4135-162a-08dc4cb7d1a6"), "Big House Marina" },
                    { new Guid("b475e659-1708-4938-ae0d-7ef01e31d202"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("bb6e7345-bdea-4e1b-b883-29502f39f21f"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("d89b8134-11a2-4f6d-86ac-d571abfa13ff"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" }
                });
        }
    }
}
