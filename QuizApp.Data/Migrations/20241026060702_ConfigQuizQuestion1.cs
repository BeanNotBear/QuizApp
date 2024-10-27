using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class ConfigQuizQuestion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 13, 7, 1, 941, DateTimeKind.Local).AddTicks(7162),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 12, 56, 54, 234, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "d49ce17e-fa96-4872-8cf9-10bdb0bcbcae");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "5631eccb-743d-420f-b3fe-b1912d0de716");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 12, 56, 54, 234, DateTimeKind.Local).AddTicks(1900),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 13, 7, 1, 941, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.AddColumn<Guid>(
                name: "QuizId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "5baac542-ddae-4b59-9fc4-470e54fb02a2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "185cc673-c42a-4f30-a9eb-88136cf7223b");
        }
    }
}
