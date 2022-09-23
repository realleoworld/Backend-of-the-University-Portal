using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealleoschoolindAPI.Migrations
{
    public partial class removecolumnscreatedOndeletedOnupdatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "course");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "course");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
                table: "course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedOn",
                table: "course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedOn",
                table: "course",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
