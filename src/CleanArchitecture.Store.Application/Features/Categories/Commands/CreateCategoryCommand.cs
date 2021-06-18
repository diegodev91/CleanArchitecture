using System;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {   
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime EndOfContract { get; set; }
    }
}