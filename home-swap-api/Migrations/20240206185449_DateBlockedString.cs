using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homeswapapi.Migrations
{
    /// <inheritdoc />
    public partial class DateBlockedString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Blocked",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Users");
        }
    }
}
