using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkInsertDemo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(nullable: false),
                    StoreNo = table.Column<int>(nullable: false),
                    ProductCode = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.Timestamp, x.StoreNo, x.ProductCode });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
