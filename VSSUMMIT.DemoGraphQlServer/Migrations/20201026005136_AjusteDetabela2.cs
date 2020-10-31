using Microsoft.EntityFrameworkCore.Migrations;

namespace VSSUMMIT.Demo00.Migrations
{
    public partial class AjusteDetabela2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Posts_PostId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Followers_PostId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Followers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Followers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followers_PostId",
                table: "Followers",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Posts_PostId",
                table: "Followers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
