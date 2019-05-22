using LibraryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework
{
    public static class LibraryContextExtension
    {
        public static void EnsureSeedDataForContext(this LibraryContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            if (context.Clients.Any())
            {
                return;
            }

            var books = new List<Book>()
            {
                new Book()
                {
                    Name = "Last Tudor",
                    Author = "Philippa Gregory",
                    //Description = "Number 1 bestselling author Philippa Gregory continues her series The Cousins' War with Jacquetta Woodville, mother of the White Quee.",
                    Description = "Number 1 bestselling",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "The Dressmaker's Secret",
                    Author = "Charlotte Betts",
                    Description = "A beautiful new novel set in Italy, 1819.",
                    //Description = "From the multi-award-winning author, comes a beautiful new novel set in Italy, 1819. It will appeal to fans of Joanne Harris and Philippa Gregory.",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "For Better, for Worse",
                    Author = "Elizabeth Jeffrey",
                    Description = "Prepareto offer Stella a warm welcome.",
                    //Description = "Newly widowed after a whirlwind wartime romance, Stella Nolan is preparing to meet her late husband's family for the first time. But not all her new in-laws are prepared to offer Stella a warm welcome.",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "Mitford Family",
                    Author = "Hugh Mitford Raymond",
                    Description = "Categoria World History",
                    //Description = "Cartea Mitford Family face parte din categoria World History a librariei.",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "Possession",
                    Author = "Erin Thompson",
                    Description = "Categoria World History",
                    //Description = "Cartea Possession face parte din categoria World History a librariei.",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "Age of the Vikings",
                    Author = "Anders Winroth",
                    Description = "Dismantles the myths surrounding the Vikings",
                    //Description = "Dismantles the myths surrounding the Vikings, allowing the full story of the period to be told, from the Vikings' innovation and pure daring to their destructive heritage.",
                    IsAvailable = true,
                    IsDeleted = false
                },
                new Book()
                {
                    Name = "Access to History: The Early Tudors: Henry VII to Mary I 148",
                    Author = "Roger Turvey",
                    Description = "Categoria British History",
                    //Description = "Cartea Access to History: The Early Tudors: Henry VII to Mary I 148 face parte din categoria British History a librariei.",
                    IsAvailable = true,
                    IsDeleted = false
                }
            };

            var clients = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Ramona",
                    SecondName = "Mihai",
                    IsDeleted = false
                },
                new Client()
                {
                    FirstName = "Catalin",
                    SecondName = "Palcu",
                    IsDeleted = false
                },
                new Client()
                {
                    FirstName = "Raluca",
                    SecondName = "Baciu",
                    IsDeleted = false
                },
                new Client()
                {
                    FirstName = "Roxana",
                    SecondName = "Coumans",
                    IsDeleted = false
                },
                new Client()
                {
                    FirstName = "Adrian",
                    SecondName = "Chebac",
                    IsDeleted = false
                },
                new Client()
                {
                    FirstName = "Angela",
                    SecondName = "Ciobanu",
                    IsDeleted = false
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
    }
}
