using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class ALlowNullsGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupsID",
                table: "StockU",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU",
                column: "GroupsID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupsID",
                table: "StockU",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU",
                column: "GroupsID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
