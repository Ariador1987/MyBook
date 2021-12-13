using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models.DTOs
{
    public class AuthorDTO
    {
        //public int Id { get; set; }
        public string FullName { get; set; }
        // Nav Props
        //public IList<Book_AuthorDTO> Book_Authors { get; set; }
    }

    public class AuthorUpdateDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        // Nav Props
        //public IList<Book_AuthorDTO> Book_Authors { get; set; }
    }
}
