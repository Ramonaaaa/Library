using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Models
{
    public class HistoryCreateViewModel
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
