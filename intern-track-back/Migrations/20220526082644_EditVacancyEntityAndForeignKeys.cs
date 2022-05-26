using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intern_track_back.Migrations
{
    public partial class EditVacancyEntityAndForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Vacancies_VacancyId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Vacancies_VacancyId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_VacancyId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_VacancyId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "TotalNumber",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "UsersCustom",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersCustom_VacancyId",
                table: "UsersCustom",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCustom_Vacancies_VacancyId",
                table: "UsersCustom",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCustom_Vacancies_VacancyId",
                table: "UsersCustom");

            migrationBuilder.DropIndex(
                name: "IX_UsersCustom_VacancyId",
                table: "UsersCustom");

            migrationBuilder.DropColumn(
                name: "TotalNumber",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "UsersCustom");

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_VacancyId",
                table: "Projects",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_VacancyId",
                table: "Contacts",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Vacancies_VacancyId",
                table: "Contacts",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Vacancies_VacancyId",
                table: "Projects",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }
    }
}
