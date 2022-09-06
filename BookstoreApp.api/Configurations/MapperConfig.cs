using AutoMapper;
using BookstoreApp.api.Data;
using BookstoreApp.api.Models.Author;
using Classroom_Test.Models.Author;

namespace BookstoreApp.api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
        }
    }
}
