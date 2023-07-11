using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSubName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubName",
                table: "FakeEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubName",
                table: "FakeEntity",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
