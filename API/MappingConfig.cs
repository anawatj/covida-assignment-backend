using AutoMapper;
using Core.Domains;
using Core.Dtos;

namespace API
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.CategoryName, t => t.MapFrom(t => t.CategoryName))
                .ForMember(t => t.Title, t => t.MapFrom(t => t.Title))
                .ForMember(t => t.Description, t => t.MapFrom(t => t.Description));

                config.CreateMap<CategoryDto, Category>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.CategoryName, t => t.MapFrom(t => t.CategoryName))
                .ForMember(t => t.Title, t => t.MapFrom(t => t.Title))
                .ForMember(t => t.Description, t => t.MapFrom(t => t.Description));

                config.CreateMap<Product, ProductDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.ProductName, t => t.MapFrom(t => t.ProductName))
                .ForMember(t => t.Title, t => t.MapFrom(t => t.Title))
                .ForMember(t => t.CategoryId, t => t.MapFrom(t => t.CategoryId))
                .ForMember(t => t.CategoryName, t => t.MapFrom(t => t.Category.CategoryName))
                .ForMember(t => t.Description, t => t.MapFrom(t => t.Description))
                .ForMember(t => t.Price, t => t.MapFrom(t => t.Price));

                config.CreateMap<User, UserDto>()
                .ForMember(t => t.Id, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.Email, t => t.MapFrom(t => t.Email))
                .ForMember(t => t.Mobile, t => t.MapFrom(t => t.Mobile))
                .ForMember(t => t.FirstName, t => t.MapFrom(t => t.FirstName))
                .ForMember(t => t.LastName, t => t.MapFrom(t => t.LastName))
                .ForMember(t => t.BirthDate, t => t.MapFrom(t => t.BirthDate))
                .ForMember(t => t.Sex, t => t.MapFrom(t => t.Sex))
                .ForMember(t => t.PrivacyAccept, t => t.MapFrom(t => t.PrivacyAccept))
                .ForMember(t => t.NewsAccept, t => t.MapFrom(t => t.NewsAccept));
            });
            return mappingConfig;

        }
    }
}
