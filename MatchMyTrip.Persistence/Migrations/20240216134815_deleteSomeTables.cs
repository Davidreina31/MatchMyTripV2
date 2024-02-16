using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchMyTrip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match_Profiles");

            migrationBuilder.DropTable(
                name: "Profile_Filters");

            migrationBuilder.DropTable(
                name: "Filters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrOfDays = table.Column<int>(type: "int", nullable: false),
                    Seasons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match_Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Profiles_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Profiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile_Filters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Filters_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Filters_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_Profiles_MatchId",
                table: "Match_Profiles",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Profiles_ProfileId",
                table: "Match_Profiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Filters_FilterId",
                table: "Profile_Filters",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Filters_ProfileId",
                table: "Profile_Filters",
                column: "ProfileId");
        }
    }
}
