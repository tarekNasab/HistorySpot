using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistorySpot.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "historicalPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicalPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "topHistoricalSites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topHistoricalSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "badges",
                columns: table => new
                {
                    BadgeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoricalPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_badges", x => x.BadgeID);
                    table.ForeignKey(
                        name: "FK_badges_historicalPoints_HistoricalPointId",
                        column: x => x.HistoricalPointId,
                        principalTable: "historicalPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricalPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_likes_historicalPoints_HistoricalPointId",
                        column: x => x.HistoricalPointId,
                        principalTable: "historicalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_badges_HistoricalPointId",
                table: "badges",
                column: "HistoricalPointId");

            migrationBuilder.CreateIndex(
                name: "IX_likes_HistoricalPointId",
                table: "likes",
                column: "HistoricalPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "badges");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "topHistoricalSites");

            migrationBuilder.DropTable(
                name: "historicalPoints");
        }
    }
}
