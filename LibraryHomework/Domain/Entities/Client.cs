using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryStore.Domain.Entities
{
    public class Client
    {
        public Client()
        {
            HistoryBooks = new HashSet<History>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }

        public bool IsDeleted { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<History> HistoryBooks { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + SecondName; } }
    }
}
