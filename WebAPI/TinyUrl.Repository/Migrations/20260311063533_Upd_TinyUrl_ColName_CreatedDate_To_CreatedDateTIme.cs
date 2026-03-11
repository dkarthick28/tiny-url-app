using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyUrl.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Upd_TinyUrl_ColName_CreatedDate_To_CreatedDateTIme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "TinyURL",
                newName: "CreatedDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "TinyURL",
                newName: "CreatedDate");
        }
    }
}
