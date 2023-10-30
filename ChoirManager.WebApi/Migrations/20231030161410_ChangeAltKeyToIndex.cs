using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoirManager.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAltKeyToIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "Alternate_Key_User",
                table: "users");

            migrationBuilder.DropUniqueConstraint(
                name: "Alternate_Key_Choir",
                table: "choirs");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "ix_choirs_name",
                table: "choirs",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_choirs_name",
                table: "choirs");

            migrationBuilder.AddUniqueConstraint(
                name: "Alternate_Key_User",
                table: "users",
                column: "email");

            migrationBuilder.AddUniqueConstraint(
                name: "Alternate_Key_Choir",
                table: "choirs",
                column: "name");
        }
    }
}
