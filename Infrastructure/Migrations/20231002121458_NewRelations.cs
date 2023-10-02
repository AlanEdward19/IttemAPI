using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Companies_CompanyId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Functions_FunctionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Polos_PoloId",
                table: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssessmentDate",
                table: "Assessments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Companies_CompanyId",
                table: "Students",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Functions_FunctionId",
                table: "Students",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Polos_PoloId",
                table: "Students",
                column: "PoloId",
                principalTable: "Polos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Companies_CompanyId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Functions_FunctionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Polos_PoloId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AssessmentDate",
                table: "Assessments");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Companies_CompanyId",
                table: "Students",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Functions_FunctionId",
                table: "Students",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Polos_PoloId",
                table: "Students",
                column: "PoloId",
                principalTable: "Polos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
