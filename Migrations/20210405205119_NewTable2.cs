using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class NewTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupsId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupsId",
                table: "AspNetUsers",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupsId",
                table: "AspNetUsers",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "AspNetUsers");
        }
    }
}
