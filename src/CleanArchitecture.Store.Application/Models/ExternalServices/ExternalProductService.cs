using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Store.Application.Models.ExternalServices
{
    public class ExternalProductService
    {
        private readonly HttpClient client;

        public ExternalProductService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://60cf49c94a030f0017f67842.mockapi.io/");
            this.client = client;
        }

        public async Task<List<ExternalProductInfo>> GetExternalProductInformation()
        {
            return await this.client.GetFromJsonAsync<List<ExternalProductInfo>>("api/v1/products");
        }
    }
}