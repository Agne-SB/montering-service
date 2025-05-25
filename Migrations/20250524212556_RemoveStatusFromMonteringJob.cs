using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonteringService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusFromMonteringJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MonteringJobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MonteringJobs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
