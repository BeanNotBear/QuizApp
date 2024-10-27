using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class ConfigQuizQuestion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 13, 35, 30, 739, DateTimeKind.Local).AddTicks(6514),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 13, 32, 18, 637, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "b7ba6c4b-0e43-4219-b924-0d625ad5ab0b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "8083e046-4e83-47f5-a5bf-0b54f6cf2b36");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 13, 32, 18, 637, DateTimeKind.Local).AddTicks(9787),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 13, 35, 30, 739, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c35fe5b-cb5d-4072-9168-79f725c1f605"),
                column: "ConcurrencyStamp",
                value: "17db6e57-856d-41d5-ab33-ce7e2f24bbfd");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "05b5d27b-390d-4e41-a0c2-f0c645d2b05e");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
