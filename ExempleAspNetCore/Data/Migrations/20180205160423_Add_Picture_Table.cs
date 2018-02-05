using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExempleAspNetCore.Data.Migrations
{
    public partial class Add_Picture_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PictureId",
                table: "Courses",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Picture_PictureId",
                table: "Courses",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Picture_PictureId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PictureId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Courses");
        }
    }
}
