using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recruiter.api.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Callback",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Reviewers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Reviewers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Closed",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Callback",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Reviewers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "Reviewers",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Closed",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Available",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
