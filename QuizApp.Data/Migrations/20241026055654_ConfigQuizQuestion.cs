using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class ConfigQuizQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizId",
                table: "Questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 12, 56, 54, 234, DateTimeKind.Local).AddTicks(1900),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 25, 9, 0, 59, 328, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId1",
                table: "QuizQuestions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuizId1",
                table: "QuizQuestions",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionId1",
                table: "QuizQuestions",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId1",
                table: "QuizQuestions",
                column: "QuizId1");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId1",
                table: "QuizQuestions",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId1",
                table: "QuizQuestions",
                column: "QuizId1",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId1",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId1",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_QuestionId1",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_QuizId1",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionId1",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "QuizId1",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "UserQuizes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 25, 9, 0, 59, 328, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 12, 56, 54, 234, DateTimeKind.Local).AddTicks(1900));

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

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
