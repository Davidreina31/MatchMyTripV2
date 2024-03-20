using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchMyTrip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addSubFieldToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sub",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sub",
                table: "Users");
        }
    }
}
