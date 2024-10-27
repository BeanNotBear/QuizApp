using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class requireEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 25, 9, 0, 59, 328, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 24, 23, 13, 41, 48, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "9b6fa38d-4609-442e-ba5d-4ea0078aa833");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "150791d2-8a42-4d2c-ab92-1ac3f4c7ee9e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 24, 23, 13, 41, 48, DateTimeKind.Local).AddTicks(1633),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 25, 9, 0, 59, 328, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "1c1eaafe-32a5-47d2-a0ae-f0f53006c705");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "9f08cf59-19dc-47da-afec-7bbde0d7fd78");
        }
    }
}
