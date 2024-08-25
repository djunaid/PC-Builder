using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "PriceComponents",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PriceComponents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "PCComponent",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PCComponent",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ApplicationUserId",
                table: "Tag",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceComponents_ApplicationUserId",
                table: "PriceComponents",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponent_ApplicationUserId",
                table: "PCComponent",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCComponent_AspNetUsers_ApplicationUserId",
                table: "PCComponent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceComponents_AspNetUsers_ApplicationUserId",
                table: "PriceComponents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_ApplicationUserId",
                table: "Tag",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCComponent_AspNetUsers_ApplicationUserId",
                table: "PCComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceComponents_AspNetUsers_ApplicationUserId",
                table: "PriceComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_ApplicationUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ApplicationUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_PriceComponents_ApplicationUserId",
                table: "PriceComponents");

            migrationBuilder.DropIndex(
                name: "IX_PCComponent_ApplicationUserId",
                table: "PCComponent");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PriceComponents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PCComponent");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "PriceComponents",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "PCComponent",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
