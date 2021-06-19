using System;
using FluentValidation;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.Stock)
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ImageUrl)
                .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.CategoryId)
            .NotEqual(0).WithMessage("{PropertyName} should not be 0")
            .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}