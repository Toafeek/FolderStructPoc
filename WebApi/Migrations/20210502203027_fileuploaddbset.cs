using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class fileuploaddbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUpload_Folders_FolderId",
                table: "FileUpload");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileUpload",
                table: "FileUpload");

            migrationBuilder.RenameTable(
                name: "FileUpload",
                newName: "FileUploads");

            migrationBuilder.RenameIndex(
                name: "IX_FileUpload_FolderId",
                table: "FileUploads",
                newName: "IX_FileUploads_FolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileUploads",
                table: "FileUploads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploads_Folders_FolderId",
                table: "FileUploads",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploads_Folders_FolderId",
                table: "FileUploads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileUploads",
                table: "FileUploads");

            migrationBuilder.RenameTable(
                name: "FileUploads",
                newName: "FileUpload");

            migrationBuilder.RenameIndex(
                name: "IX_FileUploads_FolderId",
                table: "FileUpload",
                newName: "IX_FileUpload_FolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileUpload",
                table: "FileUpload",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUpload_Folders_FolderId",
                table: "FileUpload",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
