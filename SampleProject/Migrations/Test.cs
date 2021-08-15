using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProject.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "NameId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationContents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizationContents_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizationContents_Localizations_LocalizationId",
                        column: x => x.LocalizationId,
                        principalTable: "Localizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Localizations_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Localizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_NameId",
                table: "Posts",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationContents_LanguageCode",
                table: "LocalizationContents",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationContents_LocalizationId",
                table: "LocalizationContents",
                column: "LocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AboutId",
                table: "Users",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Localizations_NameId",
                table: "Posts",
                column: "NameId",
                principalTable: "Localizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Localizations_NameId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "LocalizationContents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropIndex(
                name: "IX_Posts_NameId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
