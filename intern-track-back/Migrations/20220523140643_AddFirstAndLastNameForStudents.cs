using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intern_track_back.Migrations
{
    public partial class AddFirstAndLastNameForStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UsersCustom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UsersCustom",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UsersCustom");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UsersCustom");
        }
    }
}
