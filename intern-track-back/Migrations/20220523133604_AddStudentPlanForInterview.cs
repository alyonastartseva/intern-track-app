using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intern_track_back.Migrations
{
    public partial class AddStudentPlanForInterview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentPlanForInterviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PreferableTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlanForInterviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPlanForInterviews_UsersCustom_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "UsersCustom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPlanForInterviews_UsersCustom_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UsersCustom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StackForInterviewPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StackType = table.Column<int>(type: "int", nullable: false),
                    StudentPlanForInterviewId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlanForInterviews_CompanyId",
                table: "StudentPlanForInterviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlanForInterviews_StudentId",
                table: "StudentPlanForInterviews",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StackForInterviewPlans");

            migrationBuilder.DropTable(
                name: "StudentPlanForInterviews");
        }
    }
}
