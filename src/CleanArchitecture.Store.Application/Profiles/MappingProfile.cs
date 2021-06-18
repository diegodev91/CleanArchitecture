using AutoMapper;
using CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>();
        }
    }
}