using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_68_BE.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Air_Date",
                columns: table => new
                {
                    Air_Date_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Air_Date_Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Air_Date", x => x.Air_Date_ID);
                });

            migrationBuilder.CreateTable(
                name: "Anime_Type",
                columns: table => new
                {
                    Anime_Type_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anime_Type_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Anime_Type_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Type", x => x.Anime_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    News_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    New_Name = table.Column<string>(maxLength: 50, nullable: true),
                    New_Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.News_ID);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Studio_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studio_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Studio_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Studio_ID);
                });

            migrationBuilder.CreateTable(
                name: "Viewer",
                columns: table => new
                {
                    Viewer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Viewer_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Viewer_Email = table.Column<string>(maxLength: 50, nullable: false),
                    Viewer_Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewer", x => x.Viewer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Cmt_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Viewer_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Comment_ID);
                    table.ForeignKey(
                        name: "FK_Comment_Viewer",
                        column: x => x.Viewer_ID,
                        principalTable: "Viewer",
                        principalColumn: "Viewer_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Anime_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studio_ID = table.Column<int>(nullable: true),
                    Anime_Name = table.Column<string>(maxLength: 100, nullable: false),
                    Epsodes_Total = table.Column<int>(nullable: true),
                    Anime_Type_ID = table.Column<int>(nullable: false),
                    Air_Date_ID = table.Column<int>(nullable: false),
                    ViewCount = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    Comment_ID = table.Column<int>(nullable: true),
                    Anime_Img = table.Column<string>(maxLength: 50, nullable: true),
                    Anime_Source = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Anime_ID);
                    table.ForeignKey(
                        name: "FK_Animes_Air_Date",
                        column: x => x.Anime_Type_ID,
                        principalTable: "Air_Date",
                        principalColumn: "Air_Date_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animes_Anime_Type",
                        column: x => x.Anime_Type_ID,
                        principalTable: "Anime_Type",
                        principalColumn: "Anime_Type_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animes_Comment",
                        column: x => x.Comment_ID,
                        principalTable: "Comment",
                        principalColumn: "Comment_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animes_Studio",
                        column: x => x.Studio_ID,
                        principalTable: "Studio",
                        principalColumn: "Studio_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_Anime_Type_ID",
                table: "Animes",
                column: "Anime_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_Comment_ID",
                table: "Animes",
                column: "Comment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_Studio_ID",
                table: "Animes",
                column: "Studio_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Viewer_ID",
                table: "Comment",
                column: "Viewer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Air_Date");

            migrationBuilder.DropTable(
                name: "Anime_Type");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropTable(
                name: "Viewer");
        }
    }
}
