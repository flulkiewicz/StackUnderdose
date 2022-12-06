using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackUnderdose.Migrations
{
    /// <inheritdoc />
    public partial class StateValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unanswered",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unanswered");
        }
    }
}
