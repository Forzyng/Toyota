using Microsoft.EntityFrameworkCore.Migrations;

namespace Toyota.Data.Migrations
{
    public partial class Update_Callback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Callbacks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Callbacks");
        }
    }
}
