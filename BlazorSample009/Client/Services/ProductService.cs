using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSample009.Shared;

namespace BlazorSample009.Client.Services 
{ 
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }
    }
}