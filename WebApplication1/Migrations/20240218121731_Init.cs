using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "value",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fileName = table.Column<string>(type: "text", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    timeInSeconds = table.Column<int>(type: "integer", nullable: false),
                    indicatorValue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_value", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    filename = table.Column<string>(type: "text", nullable: false),
                    totalTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    startTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    averageExecutionTime = table.Column<double>(type: "double precision", nullable: false),
                    averageIndicatorValue = table.Column<double>(type: "double precision", nullable: false),
                    medianIndicatorValue = table.Column<double>(type: "double precision", nullable: false),
                    maxIndicatorValue = table.Column<decimal>(type: "numeric", nullable: false),
                    minIndicatorValue = table.Column<decimal>(type: "numeric", nullable: false),
                    rowsCount = table.Column<int>(type: "integer", nullable: false),
                    valueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_result_value_valueId",
                        column: x => x.valueId,
                        principalTable: "value",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_result_valueId",
                table: "result",
                column: "valueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.DropTable(
                name: "value");
        }
    }
}
