using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Organizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: true,
                defaultValue: 101);

            migrationBuilder.AddColumn<int>(
                name: "OrgnizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrganizationId", "OrgnizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 27, 220, DateTimeKind.Local).AddTicks(2125), 101, null });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrganizationId", "OrgnizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 27, 220, DateTimeKind.Local).AddTicks(2170), 102, null });

            migrationBuilder.InsertData(
                table: "organization",
                columns: new[] { "Id", "Address_City", "Address_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "św. Filipa 17", "2837984", "WSEI", "19273918739" },
                    { 102, "Łódź", "Dworcowa 7", "276567764", "ASDASD", "192876876876718739" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrgnizationId",
                table: "contacts",
                column: "OrgnizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_organization_OrgnizationId",
                table: "contacts",
                column: "OrgnizationId",
                principalTable: "organization",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_organization_OrgnizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrgnizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrgnizationId",
                table: "contacts");

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 51, 1, 576, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 51, 1, 576, DateTimeKind.Local).AddTicks(1883));
        }
    }
}
