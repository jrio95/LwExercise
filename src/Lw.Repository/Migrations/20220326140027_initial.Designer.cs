// <auto-generated />
using Lw.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lw.Repository.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20220326140027_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lw.Domain.Entities.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "English"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Spanish"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "French"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "German"
                        },
                        new
                        {
                            LanguageId = 5,
                            Name = "Portuguese"
                        });
                });

            modelBuilder.Entity("Lw.Domain.Entities.Translation", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranslationId"), 1L, 1);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("SentenceId")
                        .HasColumnType("int");

                    b.Property<string>("TranslatedSentence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TranslationId");

                    b.HasAlternateKey("LanguageId", "SentenceId");

                    b.ToTable("Translations");

                    b.HasData(
                        new
                        {
                            TranslationId = 1,
                            LanguageId = 1,
                            SentenceId = 1,
                            TranslatedSentence = "Hello. How are you?"
                        },
                        new
                        {
                            TranslationId = 2,
                            LanguageId = 2,
                            SentenceId = 1,
                            TranslatedSentence = "Hola. ¿Cómo estás?"
                        },
                        new
                        {
                            TranslationId = 3,
                            LanguageId = 3,
                            SentenceId = 1,
                            TranslatedSentence = "Bonjour. Comment allez-vous?"
                        },
                        new
                        {
                            TranslationId = 4,
                            LanguageId = 4,
                            SentenceId = 1,
                            TranslatedSentence = "Hallo. Wie geht es Ihnen?"
                        },
                        new
                        {
                            TranslationId = 5,
                            LanguageId = 5,
                            SentenceId = 1,
                            TranslatedSentence = "Olá. Como está?"
                        });
                });

            modelBuilder.Entity("Lw.Domain.Entities.Translation", b =>
                {
                    b.HasOne("Lw.Domain.Entities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
