using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LibraryHomework.Models;

namespace LibraryStore.Domain.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> option)
            : base(option)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<LibraryHomework.Models.HistoryViewModel> HistoryViewModel { get; set; }

    }
}
