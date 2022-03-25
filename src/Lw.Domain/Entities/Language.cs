using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Domain.Entities
{
    /// <summary>
    /// Languages
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Language Id
        /// </summary>
        [Key]
        public int LanguageId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
