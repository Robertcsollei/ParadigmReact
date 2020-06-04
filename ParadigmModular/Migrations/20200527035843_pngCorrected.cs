using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmModular.Migrations
{
    public partial class pngCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Texture",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "models/watchFrontTexture.jpg");
        }
    }
}
