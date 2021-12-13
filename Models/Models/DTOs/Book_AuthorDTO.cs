using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models.DTOs
{
    public class Book_AuthorDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDTO Book { get; set; }
        public int AuthorId { get; set; }
        public AuthorDTO Author { get; set; }
    }
}
