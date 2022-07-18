using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATS.Infra.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    cardNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    cvv = table.Column<int>(type: "INTEGER", nullable: false),
                    registrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    token = table.Column<long>(type: "INTEGER", nullable: false),
                    cardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCard", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCard");
        }
    }
}
