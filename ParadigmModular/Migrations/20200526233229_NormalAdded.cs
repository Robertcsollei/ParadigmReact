using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadigmModular.Migrations
{
    public partial class NormalAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalMapPath",
                value: "models/watchFrontTexture.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StandardShader",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalMapPath",
                value: "");
        }
    }
}
