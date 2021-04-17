using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Symbol = table.Column<string>(type: "longtext", nullable: true),
                    Current_price = table.Column<double>(type: "double", nullable: false),
                    Market_cap = table.Column<double>(type: "double", nullable: false),
                    Market_cap_rank = table.Column<double>(type: "double", nullable: false),
                    Total_volume = table.Column<double>(type: "double", nullable: false),
                    High_24h = table.Column<double>(type: "double", nullable: false),
                    Low_24h = table.Column<double>(type: "double", nullable: false),
                    Price_change_24h = table.Column<double>(type: "double", nullable: false),
                    Market_cap_change_24h = table.Column<double>(type: "double", nullable: false),
                    Market_cap_change_percentage_24h = table.Column<double>(type: "double", nullable: false),
                    Circulating_supply = table.Column<double>(type: "double", nullable: false),
                    Last_updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created_on = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
