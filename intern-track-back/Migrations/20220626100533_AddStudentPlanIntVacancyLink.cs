using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intern_track_back.Migrations
{
    public partial class AddStudentPlanIntVacancyLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StackForInterviewPlans");

            migrationBuilder.DropColumn(
                name: "Stack",
                table: "Interviews");

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentPlanIntVacancyLinks",
                columns: table => new
                {
                    StudentPlanForInterviewId = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlanIntVacancyLinks", x => new { x.StudentPlanForInterviewId, x.VacancyId });
                    table.ForeignKey(
                        name: "FK_StudentPlanIntVacancyLinks_StudentPlanForInterviews_StudentPlanForInterviewId",
                        column: x => x.StudentPlanForInterviewId,
                        principalTable: "StudentPlanForInterviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPlanIntVacancyLinks_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_VacancyId",
                table: "Interviews",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlanIntVacancyLinks_VacancyId",
                table: "StudentPlanIntVacancyLinks",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Vacancies_VacancyId",
                table: "Interviews",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Vacancies_VacancyId",
                table: "Interviews");

            migrationBuilder.DropTable(
                name: "StudentPlanIntVacancyLinks");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_VacancyId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Interviews");

            migrationBuilder.AddColumn<string>(
                name: "Stack",
                table: "Interviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StackForInterviewPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentPlanForInterviewId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StackType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StackForInterviewPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StackForInterviewPlans_StudentPlanForInterviews_StudentPlanForInterviewId",
                        column: x => x.StudentPlanForInterviewId,
                        principalTable: "StudentPlanForInterviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StackForInterviewPlans_StudentPlanForInterviewId",
                table: "StackForInterviewPlans",
                column: "StudentPlanForInterviewId");
        }
    }
}
