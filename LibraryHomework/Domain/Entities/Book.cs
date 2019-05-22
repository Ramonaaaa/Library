using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryStore.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            History = new HashSet<History>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<History> History { get; set; }
    }
}
