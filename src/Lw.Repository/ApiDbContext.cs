using Lw.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Repository
{
    /// <summary>
    /// Api db context
    /// </summary>
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {

        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().Build();

            var connectionString = configuration.GetConnectionString("db");
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>().HasOne<Language>().WithMany().HasForeignKey(x => x.LanguageId);
            modelBuilder.Entity<Translation>().HasIndex(x => new { x.LanguageId, x.SentenceId });

            modelBuilder.Entity<Language>().HasData(new Language() { LanguageId = 1, Name = "English"});
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageId = 2, Name = "Spanish" });
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageId = 3, Name = "French" });
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageId = 4, Name = "German" });
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageId = 5, Name = "Portuguese" });

            modelBuilder.Entity<Translation>().HasData(new Translation() { TranslationId = 1, LanguageId = 1, SentenceId = 1, TranslatedSentence = "Hello. How are you?" });
            modelBuilder.Entity<Translation>().HasData(new Translation() { TranslationId = 2, LanguageId = 2, SentenceId = 1, TranslatedSentence = "Hola. ¿Cómo estás?" });
            modelBuilder.Entity<Translation>().HasData(new Translation() { TranslationId = 3, LanguageId = 3, SentenceId = 1, TranslatedSentence = "Bonjour. Comment allez-vous?" });
            modelBuilder.Entity<Translation>().HasData(new Translation() { TranslationId = 4, LanguageId = 4, SentenceId = 1, TranslatedSentence = "Hallo. Wie geht es Ihnen?" });
            modelBuilder.Entity<Translation>().HasData(new Translation() { TranslationId = 5, LanguageId = 5, SentenceId = 1, TranslatedSentence = "Olá. Como está?" });
        }

        /// <summary>
        /// Translations
        /// </summary>
        public virtual DbSet<Translation> Translations { get; set; }

        /// <summary>
        /// Languages
        /// </summary>
        public virtual DbSet<Language> Languages { get; set; }
    }
}
