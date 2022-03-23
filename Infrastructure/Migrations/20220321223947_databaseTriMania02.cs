using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class databaseTriMania02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DeletionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDay", "CreationDate" },
                values: new object[] { new DateTime(2022, 3, 21, 19, 39, 47, 523, DateTimeKind.Local).AddTicks(6335), new DateTime(2022, 3, 21, 19, 39, 47, 524, DateTimeKind.Local).AddTicks(1841) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDay", "CreationDate" },
                values: new object[] { new DateTime(2022, 3, 19, 17, 46, 31, 398, DateTimeKind.Local).AddTicks(8956), new DateTime(2022, 3, 19, 17, 46, 31, 399, DateTimeKind.Local).AddTicks(4565) });
        }
    }
}
