using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Models.ExternalServices;

namespace CleanArchitecture.Store.Application.Contracts.Infrastructure
{
    public interface IExternalProductService
    {
        Task<List<ExternalProductInfo>> GetExternalProductInformation();
    }
}