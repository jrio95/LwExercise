using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lw.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentenceId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    TranslatedSentence = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationId);
                    table.UniqueConstraint("AK_Translations_LanguageId_SentenceId", x => new { x.LanguageId, x.SentenceId });
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Spanish" },
                    { 3, "French" },
                    { 4, "German" },
                    { 5, "Portuguese" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "TranslationId", "LanguageId", "SentenceId", "TranslatedSentence" },
                values: new object[,]
                {
                    { 1, 1, 1, "Hello. How are you?" },
                    { 2, 2, 1, "Hola. ¿Cómo estás?" },
                    { 3, 3, 1, "Bonjour. Comment allez-vous?" },
                    { 4, 4, 1, "Hallo. Wie geht es Ihnen?" },
                    { 5, 5, 1, "Olá. Como está?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
