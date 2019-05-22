using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Models
{
    public class HistoryViewModel
    {     
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Borrowed day")]
        public DateTime BorrowedDay { get; set; }

        [Display(Name = "Returned day")]
        public DateTime? ReturnedDay { get; set; }

        [Display(Name ="Client name")]
        public string ClientName { get; set; }

        [Display(Name = "Book title")]
        public string BookTitle { get; set; }

    }
}
