using BookAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Configurations.Entities
{
    internal class BookSeedConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "1st Book Title",
                    Description = "1st Book Description",
                    IsRead = true,
                    DateRead = DateTime.Now.AddDays(-10),
                    Rating = 4,
                    Genre = "Biography",
                    Author = "First Author",
                    CoverUrl = "https...",
                    DateAdded = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    Title = "2nd Book Title",
                    Description = "2nd Book Description",
                    IsRead = true,
                    DateRead = DateTime.Now.AddDays(-10),
                    Rating = 4,
                    Genre = "Biography",
                    Author = "Second Author",
                    CoverUrl = "https...",
                    DateAdded = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    Title = "3rd Book Title",
                    Description = "3rd Book Description",
                    IsRead = true,
                    DateRead = DateTime.Now.AddDays(-10),
                    Rating = 3,
                    Genre = "Biography",
                    Author = "Third Author",
                    CoverUrl = "https...",
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}
