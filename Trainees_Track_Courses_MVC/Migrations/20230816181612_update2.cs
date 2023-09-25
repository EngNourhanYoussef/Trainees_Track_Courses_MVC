using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainees_Track_Courses_MVC.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Frist_Name",
                table: "AspNetUsers",
                newName: "FristName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "AspNetUsers",
                newName: "Frist_Name");
        }
    }
}
