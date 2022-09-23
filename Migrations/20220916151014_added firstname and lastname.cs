using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealleoschoolindAPI.Migrations
{
    public partial class addedfirstnameandlastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "password");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Student",
                newName: "Name");
        }
    }
}
