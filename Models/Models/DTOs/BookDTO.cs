using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models.DTOs
{
    public  class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public IList<Book_AuthorDTO> Book_Authors { get; set; }

    }

    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public IList<Book_AuthorDTO> Book_Authors { get; set; }

    }
}
