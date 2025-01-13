using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class colChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DependentRandomDataId",
                table: "RandomDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RandomDatas_DependentRandomDataId",
                table: "RandomDatas",
                column: "DependentRandomDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandomDatas_RandomDatas_DependentRandomDataId",
                table: "RandomDatas",
                column: "DependentRandomDataId",
                principalTable: "RandomDatas",
                principalColumn: "ObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandomDatas_RandomDatas_DependentRandomDataId",
                table: "RandomDatas");

            migrationBuilder.DropIndex(
                name: "IX_RandomDatas_DependentRandomDataId",
                table: "RandomDatas");

            migrationBuilder.AlterColumn<string>(
                name: "DependentRandomDataId",
                table: "RandomDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
