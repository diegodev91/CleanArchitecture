using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Contracts.Infrastructure;
using CleanArchitecture.Store.Application.Models.ExternalServices;

namespace CleanArchitecture.Store.Infrastructure.ExternalServices
{
    public class ExternalProductService : IExternalProductService
    {
        private readonly HttpClient httpClient;

        public ExternalProductService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://60cf49c94a030f0017f67842.mockapi.io/");
            this.httpClient = client;
        }

        public async Task<List<ExternalProductInfo>> GetExternalProductInformation()
        {
            return await this.httpClient.GetFromJsonAsync<List<ExternalProductInfo>>("api/v1/products");
        }
    }
}