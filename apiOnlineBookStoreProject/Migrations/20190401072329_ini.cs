using Microsoft.EntityFrameworkCore.Migrations;

namespace apiOnlineBookStoreProject.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategorys_BookCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publications_PublicationId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategorys_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "BookCategorys",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publications_PublicationId",
                table: "Books",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "PublicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategorys_BookCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publications_PublicationId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategorys_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "BookCategorys",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publications_PublicationId",
                table: "Books",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "PublicationId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
