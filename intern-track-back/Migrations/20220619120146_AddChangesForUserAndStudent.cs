using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intern_track_back.Migrations
{
    public partial class AddChangesForUserAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UsersCustom",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "UsersCustom",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "UsersCustom");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UsersCustom",
                newName: "Name");
        }
    }
}
