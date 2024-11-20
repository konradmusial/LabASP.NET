using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_organizations_OrgnizationId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrgnizationId",
                table: "contacts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6073205b-b761-44e7-8add-121b3e6427cc", "7629fc4d-93cf-4e65-9ee7-38023936bb87" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1de45251-cbba-4d07-8ee1-50a1a260abb4", "fc23dcba-7fa2-44ec-9d89-0afabe9e293f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6073205b-b761-44e7-8add-121b3e6427cc", "fc23dcba-7fa2-44ec-9d89-0afabe9e293f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1de45251-cbba-4d07-8ee1-50a1a260abb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6073205b-b761-44e7-8add-121b3e6427cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7629fc4d-93cf-4e65-9ee7-38023936bb87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc23dcba-7fa2-44ec-9d89-0afabe9e293f");

            migrationBuilder.DropColumn(
                name: "OrgnizationId",
                table: "contacts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1e1a210-41ec-4165-809d-726d8d2edbd3", "a1e1a210-41ec-4165-809d-726d8d2edbd3", "user", "USER" },
                    { "bd467397-9aec-465b-ab01-752af4d88009", "bd467397-9aec-465b-ab01-752af4d88009", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "77cc819a-6689-441f-8982-f84ffba8a8d2", 0, "6bdaea3f-6c0a-4071-9fa4-a8133cb91fd0", "maciek@wsei.edu.pl", true, false, null, "MACIEK@WSEI.EDU.PL", "MACIEK", "AQAAAAIAAYagAAAAEJElq06iUo0+kHG+c9ltd1yKUPwHp24bcha9jX+di0tn0oxneNg9SCsUJTMPoU8APA==", null, false, "4d907f98-0970-46fc-a253-9977b882662b", false, "maciek" },
                    { "8636a3a4-18c3-4d21-bc36-11d6dbc2393d", 0, "bd18ad1f-c3c2-47e2-aa76-9afc4bca42f1", "karol@wsei.edu.pl", true, false, null, "KAROL@WSEI.EDU.PL", "KAROL", "AQAAAAIAAYagAAAAEG3NvUtdqrrO7t4vI2Su2vyeAsUl6YYVr0H+miB0fXU/38w6mWTmMkHFqi31dxB2MA==", null, false, "0ba12455-7217-4c32-ab8a-8ebf86c9288d", false, "karol" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 20, 12, 4, 23, 942, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 20, 12, 4, 23, 942, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a1e1a210-41ec-4165-809d-726d8d2edbd3", "77cc819a-6689-441f-8982-f84ffba8a8d2" },
                    { "a1e1a210-41ec-4165-809d-726d8d2edbd3", "8636a3a4-18c3-4d21-bc36-11d6dbc2393d" },
                    { "bd467397-9aec-465b-ab01-752af4d88009", "8636a3a4-18c3-4d21-bc36-11d6dbc2393d" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1e1a210-41ec-4165-809d-726d8d2edbd3", "77cc819a-6689-441f-8982-f84ffba8a8d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1e1a210-41ec-4165-809d-726d8d2edbd3", "8636a3a4-18c3-4d21-bc36-11d6dbc2393d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd467397-9aec-465b-ab01-752af4d88009", "8636a3a4-18c3-4d21-bc36-11d6dbc2393d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1e1a210-41ec-4165-809d-726d8d2edbd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd467397-9aec-465b-ab01-752af4d88009");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77cc819a-6689-441f-8982-f84ffba8a8d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8636a3a4-18c3-4d21-bc36-11d6dbc2393d");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OrgnizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1de45251-cbba-4d07-8ee1-50a1a260abb4", "1de45251-cbba-4d07-8ee1-50a1a260abb4", "admin", "ADMIN" },
                    { "6073205b-b761-44e7-8add-121b3e6427cc", "6073205b-b761-44e7-8add-121b3e6427cc", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7629fc4d-93cf-4e65-9ee7-38023936bb87", 0, "7853b6f9-9986-4094-9310-416c9624f94d", "maciek@wsei.edu.pl", true, false, null, "MACIEK@WSEI.EDU.PL", "MACIEK", "AQAAAAIAAYagAAAAEHWdczWh02uk222+k/T5619r+IZ6+8KNFT+c0t7Fx/sjD9BSbxwY73ayumJ3mK4HRA==", null, false, "e49c27c6-77ce-41e2-9b1d-5d8ef2877286", false, "maciek" },
                    { "fc23dcba-7fa2-44ec-9d89-0afabe9e293f", 0, "9c0c43e8-78b3-4a89-98f3-65b099696334", "karol@wsei.edu.pl", true, false, null, "KAROL@WSEI.EDU.PL", "KAROL", "AQAAAAIAAYagAAAAEO245IMVAKvvYE9GXpgn1k/GljQvEFb7jPscgZoUqwqjO7kF9+s70OC6dw5pB1NrPQ==", null, false, "7e4487a0-f366-4e0c-94bd-ccf7261e3ee4", false, "karol" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrgnizationId" },
                values: new object[] { new DateTime(2024, 11, 20, 11, 17, 52, 409, DateTimeKind.Local).AddTicks(6928), null });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrgnizationId" },
                values: new object[] { new DateTime(2024, 11, 20, 11, 17, 52, 409, DateTimeKind.Local).AddTicks(7144), null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6073205b-b761-44e7-8add-121b3e6427cc", "7629fc4d-93cf-4e65-9ee7-38023936bb87" },
                    { "1de45251-cbba-4d07-8ee1-50a1a260abb4", "fc23dcba-7fa2-44ec-9d89-0afabe9e293f" },
                    { "6073205b-b761-44e7-8add-121b3e6427cc", "fc23dcba-7fa2-44ec-9d89-0afabe9e293f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrgnizationId",
                table: "contacts",
                column: "OrgnizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_organizations_OrgnizationId",
                table: "contacts",
                column: "OrgnizationId",
                principalTable: "organizations",
                principalColumn: "Id");
        }
    }
}
