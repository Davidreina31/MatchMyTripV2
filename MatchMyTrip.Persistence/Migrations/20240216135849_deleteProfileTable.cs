using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchMyTrip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Profiles_ProfileId",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Profiles_ProfileId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Matches",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_ProfileId",
                table: "Matches",
                newName: "IX_Matches_UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Journeys",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Journeys_ProfileId",
                table: "Journeys",
                newName: "IX_Journeys_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Users_UserId",
                table: "Journeys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Users_UserId",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Matches",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_UserId",
                table: "Matches",
                newName: "IX_Matches_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Journeys",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Journeys_UserId",
                table: "Journeys",
                newName: "IX_Journeys_ProfileId");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Profiles_ProfileId",
                table: "Journeys",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Profiles_ProfileId",
                table: "Matches",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
