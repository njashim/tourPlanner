using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FromLocation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ToLocation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TransportType = table.Column<string>(type: "text", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    EstimatedTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    RouteImagePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tour_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TourId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    TotalDistance = table.Column<double>(type: "double precision", nullable: false),
                    TotalTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TourLog_PK", x => x.Id);
                    table.ForeignKey(
                        name: "TourLog_TourId_FK",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourLog_TourId",
                table: "TourLog",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourLog");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
