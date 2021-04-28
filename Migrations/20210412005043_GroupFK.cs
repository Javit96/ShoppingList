using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class GroupFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupsID",
                table: "StockU",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StockU_GroupsID",
                table: "StockU",
                column: "GroupsID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU",
                column: "GroupsID",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockU_Groups_GroupsID",
                table: "StockU");

            migrationBuilder.DropIndex(
                name: "IX_StockU_GroupsID",
                table: "StockU");

            migrationBuilder.DropColumn(
                name: "GroupsID",
                table: "StockU");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
