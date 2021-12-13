using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models.DTOs
{
    public class PublisherDTO
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        // Nav Prop
        public IList<BookDTO> Books { get; set; }
    }

    public class PublisherUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Nav Prop
        public IList<BookDTO> Books { get; set; }
    }
}
