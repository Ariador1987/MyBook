using AutoMapper;
using BookAPI.Domain.Models;
using BookAPI.Domain.Models.DTOs;

namespace BookAPI.Domain.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<Publisher, PublisherUpdateDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
