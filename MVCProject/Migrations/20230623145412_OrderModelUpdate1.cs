using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class OrderModelUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trader_governorates_GoverId",
                table: "Trader");

            migrationBuilder.DropIndex(
                name: "IX_Trader_GoverId",
                table: "Trader");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Trader",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trader_GovernorateId",
                table: "Trader",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trader_governorates_GovernorateId",
                table: "Trader",
                column: "GovernorateId",
                principalTable: "governorates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trader_governorates_GovernorateId",
                table: "Trader");

            migrationBuilder.DropIndex(
                name: "IX_Trader_GovernorateId",
                table: "Trader");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Trader");

            migrationBuilder.CreateIndex(
                name: "IX_Trader_GoverId",
                table: "Trader",
                column: "GoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trader_governorates_GoverId",
                table: "Trader",
                column: "GoverId",
                principalTable: "governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
