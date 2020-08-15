using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoTask.Migrations
{
    public partial class ChangTypeProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Progress",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Progress",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
