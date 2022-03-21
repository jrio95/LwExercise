using Lw.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Translations
        /// </summary>
        public DbSet<Translation> Translations { get; set; }
    }
}
