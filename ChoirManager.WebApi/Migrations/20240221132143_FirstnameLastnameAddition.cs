using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoirManager.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstnameLastnameAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "last_name");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "membership_id",
                table: "choir_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "choir_user_membership_alt_key",
                table: "choir_users",
                column: "membership_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "choir_user_membership_alt_key",
                table: "choir_users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "membership_id",
                table: "choir_users");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "name");
        }
    }
}
