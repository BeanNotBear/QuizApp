using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class ConfigQuizQuestion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId1",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
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
                defaultValue: new DateTime(2024, 10, 26, 13, 32, 18, 637, DateTimeKind.Local).AddTicks(9787),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 13, 7, 1, 941, DateTimeKind.Local).AddTicks(7162));

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
                defaultValue: new DateTime(2024, 10, 26, 13, 7, 1, 941, DateTimeKind.Local).AddTicks(7162),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 10, 26, 13, 32, 18, 637, DateTimeKind.Local).AddTicks(9787));

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
                value: "d49ce17e-fa96-4872-8cf9-10bdb0bcbcae");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"),
                column: "ConcurrencyStamp",
                value: "5631eccb-743d-420f-b3fe-b1912d0de716");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionId1",
                table: "QuizQuestions",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId1",
                table: "QuizQuestions",
                column: "QuizId1");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionId1",
                table: "QuizQuestions",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizId1",
                table: "QuizQuestions",
                column: "QuizId1",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}
