using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryStore.Domain.Entities
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [Display(Name ="Borrowed day")]
        public DateTime BorrowedDay { get; set; }

        [Display(Name = "Returned day")]
        public DateTime? ReturnedDay { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("HistoryBooks")]
        public virtual Client Client { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("History")]
        public virtual Book Book { get; set; }
    }
}
