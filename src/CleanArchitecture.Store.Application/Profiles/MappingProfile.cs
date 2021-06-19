using AutoMapper;
using CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById;
using CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryList;
using CleanArchitecture.Store.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, CategoryProductDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryProductListVm>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Product, CreateProductDto>();
        }
    }
}